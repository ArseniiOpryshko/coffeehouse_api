using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace coffeehouse_api.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public ICollection<CompoundGrammProduct> Compounds { get; set; } = new List<CompoundGrammProduct>();
    }
}
