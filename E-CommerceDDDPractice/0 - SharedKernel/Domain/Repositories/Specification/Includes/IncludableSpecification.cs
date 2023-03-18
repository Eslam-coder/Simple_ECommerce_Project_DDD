using _0___SharedKernel.Domain.Entities;
using System.Linq.Expressions;


namespace _0___SharedKernel.Domain.Repositories.Specification.Includes
{
    internal class IncludableSpecification<TEntity, TProperty> : IIncludableSpecification<TEntity, TProperty>
         where TEntity : IAggregateRoot
    {
        private readonly ISpecification<TEntity> _previousSpecification;
        private readonly IncludeNode _includeNode;

        public IncludableSpecification(
            ISpecification<TEntity> previousSpecification,
            IncludeNode includeNode)
        {
            _previousSpecification = previousSpecification;
            _includeNode = includeNode;
        }

        public IncludeNode GetIncludeNode() => _includeNode;

        public IReadOnlyCollection<Expression<Func<TEntity, bool>>> GetPredicates() => _previousSpecification.GetPredicates();

        public IIncludableSpecification<TEntity, TRootProperty> Include<TRootProperty>(
            Expression<Func<TEntity, TRootProperty>> include)
        {
            return _previousSpecification.Include(include);
        }

        public ISpecification<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _previousSpecification.Where(predicate);
        }

        public IReadOnlyCollection<IncludeNode> GetIncludes()
        {
            return _previousSpecification.GetIncludes();
        }
    }
}
