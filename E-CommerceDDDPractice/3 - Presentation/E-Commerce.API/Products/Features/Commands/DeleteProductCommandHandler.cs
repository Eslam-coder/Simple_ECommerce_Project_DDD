using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.UnitOfWork;
using _0___SharedKernel.Helpers;
using _1___Domain.Categories.Entities;
using _1___Domain.Products.Entities;

namespace E_Commerce.API.Products.Features.Commands
{
    public class DeleteProductCommandHandler : IResultCommandHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _productRepository;

        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(
            IRepository<Product> productRepository, 
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var existProduct = await _productRepository.GetByIdAsync(command.Id);
            Check.NotNull(existProduct, nameof(existProduct));
            _productRepository.Delete(existProduct);
            await _unitOfWork.CompleteAsync();
            return CommandResult.Success();
        }
    }
}
