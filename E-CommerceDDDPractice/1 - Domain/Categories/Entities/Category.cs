using _0___SharedKernel.Domain.Entities;
using _1___Domain.Products.Entities;

namespace _1___Domain.Categories.Entities
{
    public class Category : Entity, IAggregateRoot
    {
        private readonly List<Product> _products = new List<Product>();

        public string Name { get; private set; }

        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
        
        private Category() 
        { 
        }
        
        public Category(string name)
        {
            UpdateDetails(name);
        }

        public void UpdateDetails(string name)
        {
            if(name is not null)
            {
               Name = name;
            }
        }
    }
}
