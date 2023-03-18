using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.UnitOfWork;
using _0___SharedKernel.Helpers;
using _1___Domain.Orders.Entities;
using _1___Domain.Orders.Events;
using _1___Domain.Orders.Services;
using MediatR;

namespace E_Commerce.API.Orders.Features.Commands
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand, Guid>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderCommandHandler(
            IRepository<Order> orderRepository,
            IUnitOfWork unitOfWork,
            IMediator mediator)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public async Task<Guid> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var spec = OrderSpecification.ById(command.ProductId, command.UserId.ToString());
            var existOrder = await _orderRepository.GetFirstOrDefaultAsync(spec);
            Check.NotNull(existOrder, nameof(existOrder));
            await SendNotificationToProduct(existOrder, command.RequiredQuantity);
            existOrder.UpdateDetails
            (
                command.RequiredQuantity
            );
            await _unitOfWork.CompleteAsync();
            return existOrder.Id;
        }

        private async Task SendNotificationToProduct(Order order, int newRequiredQunatity)
        {
            var orderUpdatedEvent = new OrderUpdatedEvent
             (
                order,
                newRequiredQunatity
             );
            await _mediator.Publish(orderUpdatedEvent);
        }
    }
}
