using _0___SharedKernel.Domain.Entities;
using _1___Domain.Categories.Entities;
using _1___Domain.Orders.Entities;

namespace _1___Domain.Products.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        private readonly List<Order> _orders = new List<Order>();

        public string Name { get; private set; }
        
        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }
        
        public byte[]? Image { get; private set; }

        public Category Category { get; private set; }
        
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();


        private Product()
        {

        }

        public Product(string name, 
            string description,
            decimal price, 
            int quantity, 
            byte[] image,
            Category category)
        {
            Category = category;
            UpdateDetails(name, description, price, quantity, image);
        }

        public void UpdateDetails(
            string name,
            string description,
            decimal price,
            int quantity,
            byte[] image)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            Image = image;
        }

        public void UpdateCategory(Category category)
        {
            Category = category;
        }
    }
}
