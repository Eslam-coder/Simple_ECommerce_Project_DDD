using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _1___Domain.Categories.Entities;
using E_Commerce.API.Categories.Dtos;
using E_Commerce.API.Categories.Services;


namespace E_Commerce.API.Categories.Features.Queries
{
    internal class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, IReadOnlyCollection<CategoryDto>>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly ICategoryMapperService _categoryMapperService;

        public GetAllCategoriesQueryHandler(
            IRepository<Category> categoryRepository,
            ICategoryMapperService categoryMapperService) 
        { 
            _categoryRepository = categoryRepository;
            _categoryMapperService = categoryMapperService;
        }

        public async Task<IReadOnlyCollection<CategoryDto>> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var result = _categoryMapperService.MapCategoriesToDto(categories);
            return result;
        }
    }
}
