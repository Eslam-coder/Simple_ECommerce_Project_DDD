using _0___SharedKernel.CQRS;
using FluentValidation;

namespace E_Commerce.API.Categories.Features.Commands
{
    public class CreateCategoryCommand : ICommand<Guid>
    {
        public string Name { get; set; }
    }

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator() 
        {
            RuleFor(category => category.Name).NotEmpty();  
        }
    }
}
