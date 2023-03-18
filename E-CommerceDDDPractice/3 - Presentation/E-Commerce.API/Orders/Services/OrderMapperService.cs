using _1___Domain.Orders.Entities;
using AutoMapper;
using E_Commerce.API.Orders.Dtos;

namespace E_Commerce.API.Orders.Services
{
    public class OrderMapperService : IOrderMapperService
    {
        private readonly IMapper _mapper;

        public OrderMapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IReadOnlyCollection<OrderDto> MapOrdersToDto(IReadOnlyCollection<Order> orders)
        {
            var result = _mapper.Map<IReadOnlyCollection<OrderDto>>(orders);
            return result;
        }

        public OrderDto MapOrderToDto(Order order)
        {
            var result = _mapper.Map<OrderDto>(order);
            return result;
        }
    }
}
