using _0___SharedKernel.Domain.Entities;
using _0___SharedKernel.Domain.Repositories.Specification;

namespace _0___SharedKernel.Domain.Repositories
{
    public interface IRepository<TEntity, TKey> 
           where TEntity : IAggregateRoot, IEntity<TKey>
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(ISpecification<TEntity> specification);

        Task<TEntity> GetByIdAsync(TKey id);

        Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity> specification);

        Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity> specification);

        Task<int> CountAsync(ISpecification<TEntity> specification);

        Task<bool> AnyAsync(ISpecification<TEntity> specification);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entity);

        void Delete(TEntity entity);

        void Delete(TKey id);

        void DeleteRange(IEnumerable<TKey> ids);

        void Delete(ISpecification<TEntity> specification);
    }
}
