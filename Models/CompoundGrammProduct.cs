using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace coffeehouse_api.Models
{
    public class CompoundGrammProduct
    {
        [Key]
        public int Id { get; set; }
        public Compound Compound{ get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int Gramm {  get; set; }
    }
}
