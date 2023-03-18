using _0___SharedKernel.CQRS;
using E_Commerce.API.Categories.Dtos;
using FluentValidation;

namespace E_Commerce.API.Categories.Features.Queries
{
    public class GetCategoryByIdQuery : GetByIdQuery<CategoryDto>
    {
        public GetCategoryByIdQuery(Guid id) : base(id)
        {

        }
    }

    public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidator()
        {
            RuleFor(category => category.Id).NotEmpty();
        }
    }
}
