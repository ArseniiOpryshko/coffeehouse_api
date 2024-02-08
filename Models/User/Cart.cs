using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace coffeehouse_api.Models.User
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [DefaultValue(0)]
        public decimal Price { get; set; }
        public ICollection<ProductInCart>? ProductInCarts { get; set; }
    }
}
