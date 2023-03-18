using _0___SharedKernel.Domain.Entities;
using _0___SharedKernel.Domain.Repositories.Specification;
using System;
using System.Linq.Expressions;

namespace _0___SharedKernel.Domain.Repositories
{
    public static class RepositoryExtensions
    {
        public static Task<IReadOnlyCollection<TEntity>> GetAllAsync<TEntity, TPrimaryKey>(
            this IRepository<TEntity, TPrimaryKey> repository)
            where TEntity : class, IEntity<TPrimaryKey>, IAggregateRoot
        {
            return repository.GetAllAsync(new Specification<TEntity>());
        }
    }
}
