using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.UnitOfWork;
using _0___SharedKernel.Helpers;
using _1___Domain.Categories.Entities;

namespace E_Commerce.API.Categories.Features.Commands
{
    internal class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, Guid>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public UpdateCategoryCommandHandler(
            IRepository<Category> categoryRepository,
            IUnitOfWork unitOfWork) 
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var existCategory = await _categoryRepository.GetByIdAsync(command.Id);
            Check.NotNull(existCategory, nameof(existCategory));
            existCategory.UpdateDetails
            (
                command.Name
            );
            await _unitOfWork.CompleteAsync();
            return existCategory.Id;
        }
    }
}
