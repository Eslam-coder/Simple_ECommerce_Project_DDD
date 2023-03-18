namespace E_Commerce.API.Orders.Dtos
{
    public class OrderDto
    {
        public Guid ProductId { get; set; }
        
        public Guid UserId { get; set; }
        
        public Guid Id { get; set; }

        public int RequiredQuantity { get; set; }
        
        public string ProductName { get; set; }
        
        public string UserName { get; set; }

    }
}
