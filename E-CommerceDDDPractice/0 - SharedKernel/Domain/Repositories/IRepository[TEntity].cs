using _0___SharedKernel.Domain.Entities;

namespace _0___SharedKernel.Domain.Repositories
{
    public interface IRepository<TEntity> : IRepository<TEntity, Guid>
        where TEntity : IAggregateRoot, IEntity
    {
    }
}
