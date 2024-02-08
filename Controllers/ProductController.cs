using coffeehouse_api.Data.ProductRepos;
using coffeehouse_api.Dtos;
using coffeehouse_api.Models;
using coffeehouse_api.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Museum.Data;

namespace coffeehouse_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet("GetSweets")]
        public async Task<IEnumerable<Product>> GetSweets()
        {
            return await repository.GetSweets();
        }
        [HttpGet("GetDrinks")]
        public async Task<IEnumerable<Product>> GetDrinks()
        {
            return await repository.GetDrinks();
        }
        [HttpGet("GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            Product? product = await repository.GetById(id);

            if (product == null)
            {
                return BadRequest("Product not found");        
            }
            return product;
        }
        [HttpPost("AddToCart")]
        public async Task<ActionResult<int>> AddToCart(AddToCartDto dto)
        {
            return await repository.AddToCart(dto.productId, dto.cartId);
        }
        [HttpGet("GetCart")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            return await repository.GetCart(id);
        }

        [HttpPost("ConfirmOrder")]
        public async Task<ActionResult<Cart>> ConfirmOrder(ConfirmDto dto)
        {
            return await repository.ConfirmOrder(dto.cartId, dto.products);
        }
    }
}
