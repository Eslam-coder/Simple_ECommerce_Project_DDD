using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Helpers;
using _1___Domain.Orders.Entities;
using _1___Domain.Products.Entities;
using E_Commerce.API.Orders.Dtos;
using E_Commerce.API.Orders.Services;
using E_Commerce.API.Products.Dtos;
using E_Commerce.API.Products.Features.Queries;
using E_Commerce.API.Products.Services;

namespace E_Commerce.API.Orders.Features.Queries
{
    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IRepository<Order> _orderRepository;

        private readonly IOrderMapperService _orderMapperService;

        public GetOrderByIdQueryHandler(
            IRepository<Order> orderRepository,
            IOrderMapperService orderMapperService)
        {
            _orderRepository = orderRepository;
            _orderMapperService = orderMapperService;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(query.Id);
            Check.NotNull(order, nameof(order));
            var result = _orderMapperService.MapOrderToDto(order);
            return result;
        }
    }
}
