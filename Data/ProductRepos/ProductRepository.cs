using coffeehouse_api.Models;
using coffeehouse_api.Models.User;
using Microsoft.EntityFrameworkCore;
using Museum.Data;
using System.Linq;

namespace coffeehouse_api.Data.ProductRepos
{
    public class ProductRepository:IProductRepository
    {
        private CoffeeHouseContext context;
        public ProductRepository(CoffeeHouseContext context) { 
            this.context = context;
        }

        public async Task<int> AddToCart(int productId, int cartId)
        {
            Product product = await context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            Cart cart = await context.Carts
                .Include(x=>x.ProductInCarts)
                .FirstOrDefaultAsync(c => c.Id == cartId);

            bool productExistsInCart = cart.ProductInCarts.Any(pic => pic.Product == product);

            if (!productExistsInCart)
            {
                ProductInCart productInCart = new ProductInCart()
                {
                    Product = product,
                    Quantity = 1,
                    IsChosen = false
                };
                cart.ProductInCarts.Add(productInCart);

                await context.SaveChangesAsync();
            }
            return productId;
        }

        public async Task<Cart> ConfirmOrder(int cartId, List<ProductInCart> products)
        {
            Cart cart = await context.Carts
                .Include(x => x.ProductInCarts)
                .ThenInclude(x=>x.Product)
                .ThenInclude(x=>x.Type)
                .FirstOrDefaultAsync(c => c.Id == cartId);


            List<ProductInCart> productsToDelete = products.Where(x=>x.IsChosen).ToList();
            foreach (var product in productsToDelete)
            {
                var productInCartToDelete = cart.ProductInCarts.FirstOrDefault(pic => pic.Id == product.Id);
                if (productInCartToDelete != null)
                {
                    cart.ProductInCarts.Remove(productInCartToDelete);
                }
            }



            await context.SaveChangesAsync();

            return cart;
        }

        public async Task<Product> GetById(int id)
        {
            Product? product = await context.Products
                .Include(x => x.Type)
                .Include(x => x.Compounds)
                .ThenInclude(x => x.Compound)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<Cart> GetCart(int id)
        {
            Cart? cart = await context.Carts
                .Include(x=>x.ProductInCarts)
                .ThenInclude(x=>x.Product)
                .ThenInclude(x=>x.Type)
                .FirstOrDefaultAsync(x=>x.Id == id);

            return cart;
        }

        public async Task<IEnumerable<Product>> GetDrinks()
        {
            List<Product> products = await context.Products
                .Include(x => x.Type)
                .Where(x => x.Type.Name == "drinks")
                .ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetSweets()
        {
            List<Product> products = await context.Products
                 .Include(x => x.Type)
                 .Where(x => x.Type.Name == "sweets")
                 .ToListAsync();

            return products;
        }
    }
}
