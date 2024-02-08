using coffeehouse_api.Models;
using coffeehouse_api.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace coffeehouse_api.Data.ProductRepos
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetSweets();
        Task<IEnumerable<Product>> GetDrinks();
        Task<Product> GetById(int id);
        Task<int> AddToCart(int productId, int cartId);
        Task<Cart> GetCart(int id);
        Task<Cart> ConfirmOrder(int cartId, List<ProductInCart> products);

    }
}
