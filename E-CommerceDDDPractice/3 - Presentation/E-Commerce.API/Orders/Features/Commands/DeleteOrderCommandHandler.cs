using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.UnitOfWork;
using _0___SharedKernel.Helpers;
using _1___Domain.Orders.Entities;
using _1___Domain.Orders.Services;
using _1___Domain.Products.Entities;

namespace E_Commerce.API.Orders.Features.Commands
{
    public class DeleteOrderCommandHandler : IResultCommandHandler<DeleteOrderCommand>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _prdocutRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(
            IRepository<Order> orderRepository,
            IRepository<Product> prdocutRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _prdocutRepository = prdocutRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var spec = OrderSpecification.ById(command.ProductId, command.UserId.ToString());
            var existOrder = await _orderRepository.GetFirstOrDefaultAsync(spec);
            Check.NotNull(existOrder, nameof(existOrder));
            var productId = existOrder.Product.Id;
            var requiredQuantity = existOrder.RequiredQuantity;
            var existProduct = await _prdocutRepository.GetByIdAsync(productId);
            var newQty = existProduct.Quantity + requiredQuantity;
            existProduct.UpdateDetails
            (
                existProduct.Name,
                existProduct.Description,
                existProduct.Price,
                newQty,
                existProduct.Image
            );
            _orderRepository.Delete(existOrder);
            await _unitOfWork.CompleteAsync();
            return CommandResult.Success();
        }
    }
}
