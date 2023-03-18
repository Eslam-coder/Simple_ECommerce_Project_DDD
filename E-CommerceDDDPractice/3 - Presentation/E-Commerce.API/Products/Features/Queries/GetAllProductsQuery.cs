using _0___SharedKernel.CQRS;
using E_Commerce.API.Orders.Dtos;
using E_Commerce.API.Products.Dtos;

namespace E_Commerce.API.Products.Features.Queries
{
    public class GetAllProductsQuery : GetAllQuery<IReadOnlyCollection<ProductDto>>
    {
    }
}
