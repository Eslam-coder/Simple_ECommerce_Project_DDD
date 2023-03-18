using _0___SharedKernel.CQRS;
using E_Commerce.API.Orders.Dtos;
using E_Commerce.API.Products.Dtos;

namespace E_Commerce.API.Orders.Features.Queries
{
    public class GetOrderByIdQuery : GetByIdQuery<OrderDto>
    {
        public GetOrderByIdQuery(Guid id) : base(id)
        {
        }
    }
}
