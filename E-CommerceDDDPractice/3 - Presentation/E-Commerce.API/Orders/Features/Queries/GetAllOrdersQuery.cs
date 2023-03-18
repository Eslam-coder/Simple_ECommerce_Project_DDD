using _0___SharedKernel.CQRS;
using E_Commerce.API.Orders.Dtos;

namespace E_Commerce.API.Orders.Features.Queries
{
    public class GetAllOrdersQuery : GetAllQuery<IReadOnlyCollection<OrderDto>>
    {
    }
}
