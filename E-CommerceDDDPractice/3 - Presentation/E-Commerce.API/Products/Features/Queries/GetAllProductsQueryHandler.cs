using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _1___Domain.Products.Entities;
using _1___Domain.Products.Services;
using E_Commerce.API.Products.Dtos;
using E_Commerce.API.Products.Services;

namespace E_Commerce.API.Products.Features.Queries
{
    internal class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, IReadOnlyCollection<ProductDto>>
    {
        private readonly IRepository<Product> _repository;
        
        private readonly IProductMapperService _productMapperService;
        
        public GetAllProductsQueryHandler(
            IRepository<Product> repository,
            IProductMapperService productMapperService)
        {
            _repository = repository;
            _productMapperService = productMapperService;
        }

        public  async Task<IReadOnlyCollection<ProductDto>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync(new ProductSpecification());
            var result = _productMapperService.MapProductsToDto(products);
            return result;
        }
    }
}
