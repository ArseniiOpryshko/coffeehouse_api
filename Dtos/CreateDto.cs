using System.Text.Json.Serialization;

namespace coffeehouse_api.Dtos
{
    public class CreateDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string type { get; set; }
        public Comp[] compounds { get; set; }

    }

    public class Comp
    {
        public int id { get; set; }
        public string name { get; set; }
        public int gram { get; set; }
        public bool isSelected { get; set; }
    }
}
