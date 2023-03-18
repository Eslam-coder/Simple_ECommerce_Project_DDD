using _1___Domain.Categories.Entities;
using AutoMapper;
using E_Commerce.API.Categories.Dtos;

namespace E_Commerce.API.Categories.Services
{
    public class CategoryMapperService : ICategoryMapperService
    {
        private readonly IMapper _mapper;

        public CategoryMapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IReadOnlyCollection<CategoryDto> MapCategoriesToDto(IReadOnlyCollection<Category> categories)
        {
            var result = _mapper.Map<IReadOnlyCollection<CategoryDto>>(categories);
            return result;
        }

        public CategoryDto MapCategoryToDto(Category category)
        {
            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }
    }
}
