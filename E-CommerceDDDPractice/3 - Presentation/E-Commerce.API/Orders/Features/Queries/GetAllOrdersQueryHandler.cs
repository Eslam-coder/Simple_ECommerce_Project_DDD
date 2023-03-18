using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _1___Domain.Orders.Entities;
using _1___Domain.Orders.Services;
using E_Commerce.API.Orders.Dtos;
using E_Commerce.API.Orders.Services;

namespace E_Commerce.API.Orders.Features.Queries
{
    internal class GetAllOrdersQueryHandler : IQueryHandler<GetAllOrdersQuery, IReadOnlyCollection<OrderDto>>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IOrderMapperService _orderMapperService;

        public GetAllOrdersQueryHandler(
            IRepository<Order> orderRepository,
            IOrderMapperService orderMapperService)
        {
            _orderRepository = orderRepository;
            _orderMapperService = orderMapperService;
        }

        public async Task<IReadOnlyCollection<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync(new OrderSpecification());
            var result = _orderMapperService.MapOrdersToDto(orders);
            return result;
        }
    }
}
