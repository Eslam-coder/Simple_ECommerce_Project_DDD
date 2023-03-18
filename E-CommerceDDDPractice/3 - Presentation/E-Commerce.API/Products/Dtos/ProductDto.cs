namespace E_Commerce.API.Products.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public byte[] Image { get; set; }

        public Guid CategoryId { get; set; }
        
        public string CategoryName { get; set; }
    }
}
