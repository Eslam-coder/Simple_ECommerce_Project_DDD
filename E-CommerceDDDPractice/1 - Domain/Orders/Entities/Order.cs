using _0___SharedKernel.Domain.Entities;
using _1___Domain.Authentication.Entities;
using _1___Domain.Products.Entities;

namespace _1___Domain.Orders.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public int RequiredQuantity { get; private set; }
        
        public Product Product { get; private set; }
        
        public User User { get; private set; }
        
        private Order()
        {
        }

        public Order(Product product, User user, int quantity)
        {
            Product = product;
            User = user;
            UpdateDetails(quantity);
        }

        public void UpdateDetails(int quantity)
        {
            if (quantity > 0)
            {
                RequiredQuantity = quantity;
            }
        }
    }
}
