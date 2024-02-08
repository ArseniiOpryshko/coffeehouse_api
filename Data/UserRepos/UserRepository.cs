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

    }
}
