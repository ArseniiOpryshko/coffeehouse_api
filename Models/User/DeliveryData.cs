using System.ComponentModel.DataAnnotations;

namespace coffeehouse_api.Models.User
{
    public class DeliveryData
    {
        [Key]
        public int Id { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
    }
}
