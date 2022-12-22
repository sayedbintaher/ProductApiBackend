namespace ProductAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ImageLink { get; set; } = string.Empty;
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Stock { get; set; }

    }
}
