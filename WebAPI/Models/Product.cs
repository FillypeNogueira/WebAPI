namespace WebAPI.Models
{
    public class Product
    {
        public long ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool Status  { get; set; }

        public long CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
