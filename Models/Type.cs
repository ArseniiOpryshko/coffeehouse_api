using System.ComponentModel.DataAnnotations;

namespace coffeehouse_api.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
