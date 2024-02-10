using coffeehouse_api.Dtos;
using coffeehouse_api.Models.User;

namespace coffeehouse_api.Data.UserRepos
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task<User> Create(User user);
        Task<User> ChangeAccountProperties(int userId, string email, byte[] passwordHash = null, byte[] passwordSalt = null);
        Task<DeliveryData> ChangeDeliveryData(int userId, string town, string street, string phone);
        Task<DeliveryData> GetDeliveryData(int userId);
    }
}
