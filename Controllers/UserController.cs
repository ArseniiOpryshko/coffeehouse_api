using coffeehouse_api.Data.UserRepos;
using coffeehouse_api.Dtos;
using coffeehouse_api.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Museum.Data.ObjsForAuth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace coffeehouse_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] Log_RegDto dto)
        {
            User? user = await repository.GetByEmail(dto.email);

            if (user == null) 
                return BadRequest("Invalid Email");

            if (!VerifyPassword(dto.password, user.PasswordHash, user.PasswordSalt))
                return BadRequest("Invalid password");

            string jwt = CreateToken(user);

            HttpContext.Response.Cookies.Append("token", jwt,
                new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(14),
                    HttpOnly = false,
                    Secure = true,
                    IsEssential = true,
                    SameSite = SameSiteMode.None
                });

            return Ok("success");
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(Log_RegDto dto)
        {
            CreatePasswordHash(dto.password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User()
            {
                Email = dto.email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await repository.Create(user);

            return Ok("Користувача створено");
        }
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private string CreateToken(User user)
        {
            var identity = GetIdentity(user);
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
               claims: identity.Claims,               
               expires: now.Add(TimeSpan.FromHours(AuthOptions.LIFETIME)),
               signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha512Signature));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
        private ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim>
                {
                    new Claim("Id", Convert.ToString(user.Id)),
                    new Claim("Email", Convert.ToString(user.Email)),
                    new Claim("cartId", Convert.ToString(user.Cart.Id)),
                    new Claim("roleId", Convert.ToString(user.Role.Id))
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}
