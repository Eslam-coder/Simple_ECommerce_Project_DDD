using _1___Domain.Categories.Entities;
using _1___Domain.Products.Entities;
using E_Commerce.API.Categories.Dtos;
using E_Commerce.API.Products.Dtos;

namespace E_Commerce.API.Categories.Services
{
    public interface ICategoryMapperService
    {
        IReadOnlyCollection<CategoryDto> MapCategoriesToDto(IReadOnlyCollection<Category> products);

        CategoryDto MapCategoryToDto(Category category);
    }
}
