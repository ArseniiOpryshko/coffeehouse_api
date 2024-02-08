using System.ComponentModel.DataAnnotations;

namespace coffeehouse_api.Models.User
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DeliveryData? DeliveryData { get; set; }
        public Cart? Cart { get; set; }
        public Role Role { get; set; }
    }
}
