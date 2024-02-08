using System.ComponentModel.DataAnnotations;

namespace coffeehouse_api.Models.User
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
