using coffeehouse_api.Models.User;

namespace coffeehouse_api.Data.UserRepos
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task<User> Create(User user);
    }
}
