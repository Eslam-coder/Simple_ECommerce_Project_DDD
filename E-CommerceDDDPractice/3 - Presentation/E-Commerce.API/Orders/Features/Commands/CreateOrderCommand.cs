using _0___SharedKernel.CQRS;

namespace E_Commerce.API.Orders.Features.Commands
{
    public class CreateOrderCommand : ICommand<Guid>
    {
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public int RequiredQuantity { get; set; }
    }
}
