using _0___SharedKernel.CQRS;
using FluentValidation;

namespace E_Commerce.API.Products.Features.Commands
{
    public class DeleteProductCommand : IResultCommand
    {
        public Guid Id { get; set; }

        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(product => product.Id).NotEmpty();
        }
    }
}
