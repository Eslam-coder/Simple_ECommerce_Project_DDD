using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.UnitOfWork;
using _0___SharedKernel.Helpers;
using _1___Domain.Categories.Entities;

namespace E_Commerce.API.Categories.Features.Commands
{
    public class DeleteCategoryCommandHandler : IResultCommandHandler<DeleteCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepository;

        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(
            IRepository<Category> categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var existCategory = await _categoryRepository.GetByIdAsync(command.Id);
            Check.NotNull(existCategory, nameof(existCategory));
            _categoryRepository.Delete(existCategory);
            await _unitOfWork.CompleteAsync();
            return CommandResult.Success();
        }
    }
}
