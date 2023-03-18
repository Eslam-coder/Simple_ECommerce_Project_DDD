using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.UnitOfWork;
using _0___SharedKernel.Helpers;
using _1___Domain.Products.Entities;

namespace E_Commerce.API.Products.Features.Commands
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Guid>
    {
        private readonly IRepository<Product> _productRepository;

        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(
            IRepository<Product> productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var existProduct = await _productRepository.GetByIdAsync(command.Id);
            Check.NotNull(existProduct, nameof(existProduct));
            existProduct.UpdateDetails
            (
                command.Name,
                command.Description,
                command.Price,
                command.Quantity,
                command.Image
            );
            await _unitOfWork.CompleteAsync();
            return existProduct.Id;
        }
    }
}
