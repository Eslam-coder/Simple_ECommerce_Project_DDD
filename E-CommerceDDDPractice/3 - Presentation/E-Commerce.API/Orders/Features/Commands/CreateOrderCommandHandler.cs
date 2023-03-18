using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.UnitOfWork;
using _1___Domain.Authentication.Entities;
using _1___Domain.Orders.Entities;
using _1___Domain.Orders.Events;
using _1___Domain.Products.Entities;
using MediatR;

namespace E_Commerce.API.Orders.Features.Commands
{
    internal class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Guid>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<User, string> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateOrderCommandHandler(
            IRepository<Order> orderRepository,
            IRepository<Product> productRepository,
            IRepository<User, string> userRepository,
            IUnitOfWork unitOfWork,
            IMediator mediator) 
        { 
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.ProductId);
            var user = await _userRepository.GetByIdAsync(command.UserId.ToString());
            var newOrder = new Order
            (
              product,
              user,
              command.RequiredQuantity
            );
            _orderRepository.Add(newOrder);
            await SendNotificationToProductOrderCreated(newOrder);
            await _unitOfWork.CompleteAsync();
            return newOrder.Id;
        }

        private async Task SendNotificationToProductOrderCreated(Order order)
        {
            var orderCreatedEvent = new OrderCreatedEvent(order);
            await _mediator.Publish(orderCreatedEvent);
        }
    }
}
