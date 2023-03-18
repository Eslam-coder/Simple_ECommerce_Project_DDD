using _0___SharedKernel.Domain.Events;
using _0___SharedKernel.Domain.UnitOfWork;
using _1___Domain.Orders.Events;

namespace _1___Domain.Orders.Services.EventHandlers
{
    public class OrderUpdatedEventHandler : IDomainEventHandler<OrderUpdatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderUpdatedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(OrderUpdatedEvent @event, CancellationToken cancellationToken)
        {
            var newRequiredQuantity = @event.NewRequiredQunatity;
            var existProduct = @event.ExistOrder.Product;
            var oldRequiredQuantity = @event.ExistOrder.RequiredQuantity;
            var diff = oldRequiredQuantity - newRequiredQuantity;
            int newQty;
            if(diff > 0)
            {
                newQty = existProduct.Quantity + diff;
            }
            else
            {
                newQty = existProduct.Quantity - Math.Abs(diff);
            }
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
