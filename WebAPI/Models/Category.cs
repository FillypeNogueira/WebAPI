using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Category
    {
        public long CategoryId { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        [JsonIgnore]
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
