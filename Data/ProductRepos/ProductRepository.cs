using coffeehouse_api.Dtos;
using coffeehouse_api.Models;
using coffeehouse_api.Models.User;
using Microsoft.EntityFrameworkCore;
using Museum.Data;
using System.Linq;
using System.Xml.Serialization;
using Type = coffeehouse_api.Models.Type;

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

        public async Task<int> CreateProduct(CreateDto data, byte[] image)
        {
            Type type = await context.Types.FirstOrDefaultAsync(x => x.Name == data.type);
            
            Product product = new Product()
            {
                Name = data.name,
                Description = data.description,
                Type = type,
                Price = Convert.ToDecimal(data.price),
                Image = image
            };

            foreach (Comp item in data.compounds)
            {
                if (item.isSelected)
                {
                    Compound compound = await context.Compounds.FirstOrDefaultAsync(x=>x.Id==item.id);
                    CompoundGrammProduct cgp = new CompoundGrammProduct()
                    {
                        Compound = compound,
                        Gramm = item.gram
                    };
                    product.Compounds.Add(cgp);
                }
            }


            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> DeleteProduct(string name)
        {
            Product product = await context.Products.FirstOrDefaultAsync(x => x.Name == name);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return product.Id;
            }
            return 0;
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

        public async Task<IEnumerable<Compound>> GetCompounds()
        {
            List<Compound> compounds = await context.Compounds.ToListAsync();
            return compounds;
        }

        public async Task<IEnumerable<Product>> GetDrinks()
        {
            List<Product> products = await context.Products
                .Include(x => x.Type)
                .Where(x => x.Type.Name == "drinks")
                .ToListAsync();
            return products;
        }

        public async Task<IEnumerable<byte[]>> GetImages(int id)
        {
            List<byte[]> bytes = await context.Products
                .Include(x=>x.Type)
                .Where(x => x.Type.Id == id)
                .Select(x => x.Image)
                .Take(4)
                .ToListAsync();
            return bytes;
        }

        public async Task<Product> GetLastProductType(int id)
        {
            Product product = await context.Products
                .Include(x => x.Type)
                .Where(x => x.Type.Id == id)
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();

            return product;
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
