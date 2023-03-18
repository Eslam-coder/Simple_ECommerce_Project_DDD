using _0___SharedKernel.CQRS;
using E_Commerce.API.Products.Dtos;

namespace E_Commerce.API.Products.Features.Queries
{
    public class GetProductByIdQuery : GetByIdQuery<ProductDto>
    {
        public GetProductByIdQuery(Guid id) : base(id) 
        {
        }
    }
}
