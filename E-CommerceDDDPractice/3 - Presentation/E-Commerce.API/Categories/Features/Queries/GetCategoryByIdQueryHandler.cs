using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Helpers;
using _1___Domain.Categories.Entities;
using E_Commerce.API.Categories.Dtos;
using E_Commerce.API.Categories.Services;

namespace E_Commerce.API.Categories.Features.Queries
{
    public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly ICategoryMapperService _categoryMapperService;

        public GetCategoryByIdQueryHandler(
            IRepository<Category> categoryRepository, 
            ICategoryMapperService categoryMapperService)
        {
            _categoryRepository = categoryRepository;
            _categoryMapperService = categoryMapperService;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(query.Id);
            Check.NotNull(category, nameof(category));
            var result = _categoryMapperService.MapCategoryToDto(category);
            return result;
        }
    }
}
