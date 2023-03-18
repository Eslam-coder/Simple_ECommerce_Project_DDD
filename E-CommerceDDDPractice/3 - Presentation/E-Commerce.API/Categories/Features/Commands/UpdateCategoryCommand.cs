using _0___SharedKernel.CQRS;
using E_Commerce.API.Categories.Dtos;
using FluentValidation;

namespace E_Commerce.API.Categories.Features.Commands
{
    public class UpdateCategoryCommand : CreateCategoryCommand
    {
        public Guid Id { get; set; }
    }

    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator() 
        {
            RuleFor(category => category.Name).NotNull().NotEmpty();
        }
    }
}
