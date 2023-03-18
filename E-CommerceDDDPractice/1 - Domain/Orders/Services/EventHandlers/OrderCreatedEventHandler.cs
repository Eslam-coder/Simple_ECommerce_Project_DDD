using _0___SharedKernel.Domain.Events;
using _0___SharedKernel.Domain.UnitOfWork;
using _1___Domain.Orders.Events;

namespace _1___Domain.Orders.Services.EventHandlers
{
    public class OrderCreatedEventHandler : IDomainEventHandler<OrderCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderCreatedEventHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(OrderCreatedEvent @event, CancellationToken cancellationToken)
        {
            var requiredQuantity = @event.Order.RequiredQuantity;
            var existProduct = @event.Order.Product;
            var newQty = existProduct.Quantity - requiredQuantity;
            existProduct.UpdateDetails
            (
                existProduct.Name,
                existProduct.Description,
                existProduct.Price,
                newQty,
                existProduct.Image
            );
            await _unitOfWork.CompleteAsync();
        }
    }
}
