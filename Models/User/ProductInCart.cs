using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace coffeehouse_api.Models.User
{
    public class ProductInCart
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public bool IsChosen { get; set; }
        [JsonIgnore]
        public ICollection<Cart>? Carts { get; set; }

    }
}
