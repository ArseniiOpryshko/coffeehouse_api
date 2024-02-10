using coffeehouse_api.Dtos;
using coffeehouse_api.Models.User;
using Microsoft.EntityFrameworkCore;
using Museum.Data;

namespace coffeehouse_api.Data.UserRepos
{
    public class UserRepository: IUserRepository
    {
        private CoffeeHouseContext context;

        public UserRepository(CoffeeHouseContext context)
        {
            this.context = context;
        }

        public async Task<User> ChangeAccountProperties(int userId, string email, byte[] passwordHash = null, byte[] passwordSalt = null)
        {
            User user = await context.Users
                .Include(x=>x.Cart)
                .Include(x=>x.Role)
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (user != null)
            {
                user.Email = email;
                if (passwordHash!=null)
                {
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                }
                
                await context.SaveChangesAsync();

                return user;    
            }

            return null;
        }

        public async Task<DeliveryData> ChangeDeliveryData(int userId, string town, string street, string phone)
        {
            User user = await context.Users
                .Include(x => x.DeliveryData)
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (user.DeliveryData != null) {
                user.DeliveryData.Town = town;
                user.DeliveryData.Street = street;
                user.DeliveryData.PhoneNumber = phone;
            }
            else
            {
                user.DeliveryData = new DeliveryData()
                {
                    Town = town,
                    Street = street,
                    PhoneNumber = phone
                };
            }
            await context.SaveChangesAsync();

            return user.DeliveryData;
        }

        public async Task<User> Create(User user)
        {
            Role? clientRole = context.Roles.Where(x => x.Name == "client").FirstOrDefault();

            Cart cart = new();
            context.Carts.Add(cart);
            await context.SaveChangesAsync();

            user.Cart = cart;
            user.Role = clientRole;
            context.Users.Add(user);
            user.Id = await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            User? user = await context.Users
                .Include(u => u.Role)
                .Include(x=>x.Cart)
                .Where(x => x.Email.Equals(email))
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<DeliveryData> GetDeliveryData(int userId)
        {
            User user = await context.Users
                 .Include(x => x.DeliveryData)
                 .FirstOrDefaultAsync(x => x.Id == userId);

            return user.DeliveryData;
        }
    }
}
