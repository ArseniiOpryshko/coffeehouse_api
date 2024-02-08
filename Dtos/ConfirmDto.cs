using coffeehouse_api.Models.User;

namespace coffeehouse_api.Dtos
{
    public class ConfirmDto
    {
        public int cartId { get; set; }
        public List<ProductInCart> products { get; set; }
    }
}
