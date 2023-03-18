using _1___Domain.Products.Entities;
using AutoMapper;
using E_Commerce.API.Products.Dtos;

namespace E_Commerce.API.Products.Services
{
    public class ProductMapperService : IProductMapperService
    {
        private readonly IMapper _mapper;

        public ProductMapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IReadOnlyCollection<ProductDto> MapProductsToDto(IReadOnlyCollection<Product> products)
        {
            var result = _mapper.Map<IReadOnlyCollection<ProductDto>>(products);
            return result;
        }

        public ProductDto MapProductToDto(Product product)
        {
            var result = _mapper.Map<ProductDto>(product);
            return result;
        }
    }
}
