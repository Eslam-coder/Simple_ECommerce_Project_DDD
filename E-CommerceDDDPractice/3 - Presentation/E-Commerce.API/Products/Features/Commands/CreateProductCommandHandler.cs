using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.UnitOfWork;
using _0___SharedKernel.Helpers;
using _1___Domain.Categories.Entities;
using _1___Domain.Products.Entities;

namespace E_Commerce.API.Products.Features.Commands
{
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
    {
        private readonly IRepository<Product> _productRepository;
        
        private readonly IRepository<Category> _categoryRepository;
        
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(
            IRepository<Product> productRepository,
            IRepository<Category> categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(command.CategoryId);
            Check.NotNull(category, nameof(category));  
            var newProduct = new Product
            (
              command.Name,
              command.Description,
              command.Price,
              command.Quantity,
              command.Image,
              category
            );
            _productRepository.Add(newProduct);
            await _unitOfWork.CompleteAsync();
            return newProduct.Id;
        }
    }
}
