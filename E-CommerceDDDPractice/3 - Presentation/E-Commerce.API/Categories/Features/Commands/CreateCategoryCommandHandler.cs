using _0___SharedKernel.CQRS;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.UnitOfWork;
using _1___Domain.Categories.Entities;

namespace E_Commerce.API.Categories.Features.Commands
{
    internal class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Guid>
    {
        private readonly IRepository<Category> _categoryRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(
            IRepository<Category> categoryRepository,
            IUnitOfWork unitOfWork) 
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var newCategory = new Category
            (
              command.Name
            );
            _categoryRepository.Add(newCategory);
            await _unitOfWork.CompleteAsync();
            return newCategory.Id;
        }
    }
}
