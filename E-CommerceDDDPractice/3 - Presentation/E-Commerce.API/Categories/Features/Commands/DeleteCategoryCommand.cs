using _0___SharedKernel.CQRS;
using FluentValidation;

namespace E_Commerce.API.Categories.Features.Commands
{
    public class DeleteCategoryCommand : IResultCommand
    {
        public Guid Id { get; set; }

        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(category => category.Id).NotEmpty();
        }
    }
}
