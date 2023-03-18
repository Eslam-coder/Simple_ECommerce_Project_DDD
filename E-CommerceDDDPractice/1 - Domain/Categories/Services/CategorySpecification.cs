using _0___SharedKernel.Domain.Repositories.Specification;
using _1___Domain.Categories.Entities;

namespace _1___Domain.Categories.Services
{
    public sealed class CategorySpecification : Specification<Category>
    {
        public CategorySpecification()
        {
        }

        public static ISpecification<Category> ById(Guid id)
        {
            var categorySpecification = new CategorySpecification();
            var result = categorySpecification.Where(category => category.Id == id);
            return result;
        }
    }
}
