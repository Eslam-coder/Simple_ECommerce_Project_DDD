using _0___SharedKernel.CQRS;
using FluentValidation;

namespace E_Commerce.API.Orders.Features.Commands
{
    public class DeleteOrderCommand : IResultCommand
    {
        public Guid ProductId { get; set; }
        
        public Guid UserId { get; set; }

        public DeleteOrderCommand(
            Guid productId,
            Guid userId)
        {
            ProductId = productId;
            UserId = userId;
        }
    }

    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(order => order.ProductId).NotEmpty();
            RuleFor(order => order.UserId).NotEmpty();
        }
    }
}
