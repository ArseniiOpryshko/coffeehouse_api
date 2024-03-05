using coffeehouse_api.Data.ProductRepos;
using coffeehouse_api.Dtos;
using coffeehouse_api.Models;
using coffeehouse_api.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Museum.Data;
using Newtonsoft.Json;

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

        [HttpDelete("DeleteWithName")]
        public async Task<ActionResult<int>> Delete(string name)
        {
            return await repository.DeleteProduct(name);
        }
        [HttpGet("GetCompounds")]
        public async Task<IEnumerable<Compound>> GetCompounds()
        {
            return await repository.GetCompounds();
        }
        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create([FromForm] IFormFile file, [FromForm] string dto)
        {
            CreateDto? dtoData = JsonConvert.DeserializeObject<CreateDto>(dto);

            byte[] imageData;
            using (var binaryReader = new BinaryReader(file.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)file.Length);
            }

            await repository.CreateProduct(dtoData, imageData);

            return 1;
        }

        [HttpGet("GetLastProductWithType")]
        public async Task<Product> GetLastDrink(int id)
        {
            return await repository.GetLastProductType(id);
        }
        [HttpGet("GetProductImgs")]
        public async Task<IEnumerable<byte[]>> GetProductImgs(int id)
        {
            return await repository.GetImages(id);
        }
    }
}
