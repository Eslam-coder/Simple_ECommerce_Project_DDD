using _1___Domain.Orders.Entities;
using E_Commerce.API.Orders.Dtos;

namespace E_Commerce.API.Orders.Services
{
    public interface IOrderMapperService
    {
        IReadOnlyCollection<OrderDto> MapOrdersToDto(IReadOnlyCollection<Order> orders);

        OrderDto MapOrderToDto(Order order);
    }
}
