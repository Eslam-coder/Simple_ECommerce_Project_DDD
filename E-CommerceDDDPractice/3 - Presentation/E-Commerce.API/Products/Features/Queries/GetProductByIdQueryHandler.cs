using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Helpers;
using _1___Domain.Products.Entities;
using E_Commerce.API.Products.Dtos;
using E_Commerce.API.Products.Services;

namespace E_Commerce.API.Products.Features.Queries
{
    internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IProductMapperService _productMapperService;
        
        public GetProductByIdQueryHandler(
            IRepository<Product> repository,
            IProductMapperService productMapperService)
        {
            _repository = repository;
            _productMapperService = productMapperService;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(query.Id);
            Check.NotNull(product, nameof(product));
            var result = _productMapperService.MapProductToDto(product);
            return result;
        }
    }
}
