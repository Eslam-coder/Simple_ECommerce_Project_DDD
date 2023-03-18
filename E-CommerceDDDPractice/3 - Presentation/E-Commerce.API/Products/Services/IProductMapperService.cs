using _1___Domain.Products.Entities;
using E_Commerce.API.Products.Dtos;

namespace E_Commerce.API.Products.Services
{
    public interface IProductMapperService
    {
        IReadOnlyCollection<ProductDto> MapProductsToDto(IReadOnlyCollection<Product> products);
        
        ProductDto MapProductToDto(Product product);
    }
}
