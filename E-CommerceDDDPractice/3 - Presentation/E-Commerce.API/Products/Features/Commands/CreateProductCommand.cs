using _0___SharedKernel.CQRS;
using FluentValidation;

namespace E_Commerce.API.Products.Features.Commands
{
    public class CreateProductCommand : ICommand<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public byte[]? Image { get; set; }

        public Guid CategoryId { get; set; }
    }

    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor(command => command.Name).NotNull();
            RuleFor(command => command.Price).NotNull();
            RuleFor(command => command.Quantity).NotNull();
            RuleFor(command => command.CategoryId).NotNull();
        }
    }
}
