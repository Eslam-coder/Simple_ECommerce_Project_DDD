using _0___SharedKernel.Domain.Repositories.Specification;
using _1___Domain.Products.Entities;

namespace _1___Domain.Products.Services
{
    public sealed class ProductSpecification : Specification<Product>
    {
        public ProductSpecification() 
        {
            Include(product => product.Category);
        }

        public static ISpecification<Product> ById(Guid id)
        {
            var productSpecification = new ProductSpecification();
            var result = productSpecification.Where(product => product.Id == id);
            return result;
        }
    }
}
