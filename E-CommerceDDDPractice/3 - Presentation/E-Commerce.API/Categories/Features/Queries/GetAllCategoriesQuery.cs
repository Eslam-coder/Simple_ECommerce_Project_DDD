using _0___SharedKernel.CQRS;
using E_Commerce.API.Categories.Dtos;

namespace E_Commerce.API.Categories.Features.Queries
{
    public class GetAllCategoriesQuery : GetAllQuery<IReadOnlyCollection<CategoryDto>>
    {
    }
}
