using _0___SharedKernel.Domain.Entities;
using _0___SharedKernel.Domain.Repositories.Specification.Includes;
using System.Linq.Expressions;

namespace _0___SharedKernel.Domain.Repositories.Specification
{
    public interface ISpecification<TEntity> where TEntity : IAggregateRoot
    {
        IReadOnlyCollection<Expression<Func<TEntity, bool>>> GetPredicates();

        IReadOnlyCollection<IncludeNode> GetIncludes();

        IIncludableSpecification<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> include);

        ISpecification<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
