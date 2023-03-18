using _0___SharedKernel.Domain.Entities;
using _0___SharedKernel.Domain.Repositories.Specification.Includes;
using System.Linq.Expressions;

namespace _0___SharedKernel.Domain.Repositories.Specification
{
    public class Specification<TEntity> : ISpecification<TEntity>
         where TEntity : IAggregateRoot
    {
        private readonly List<Expression<Func<TEntity, bool>>> _criteria = new List<Expression<Func<TEntity, bool>>>();
        private readonly List<IncludeNode> _includeNodes = new List<IncludeNode>();

        protected internal Specification(Expression<Func<TEntity, bool>> criteria)
        {
            _criteria.Add(criteria);
        }

        protected internal Specification()
        {
        }

        public IReadOnlyCollection<Expression<Func<TEntity, bool>>> GetPredicates() => _criteria.AsReadOnly();

        public IReadOnlyCollection<IncludeNode> GetIncludes()
        {
            return _includeNodes.AsReadOnly();
        }

        public IIncludableSpecification<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> include)
        {
            var includeNode = new IncludeNode(include, typeof(TEntity), typeof(TProperty));
            _includeNodes.Add(includeNode);
            return new IncludableSpecification<TEntity, TProperty>(this, includeNode);
        }

        public ISpecification<TEntity> Where(Expression<Func<TEntity, bool>> criteria)
        {
            _criteria.Add(criteria);
            return this;
        }
    }
}
