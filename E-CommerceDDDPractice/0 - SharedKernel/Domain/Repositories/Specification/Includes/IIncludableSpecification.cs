using _0___SharedKernel.Domain.Entities;

namespace _0___SharedKernel.Domain.Repositories.Specification.Includes
{
    public interface IIncludableSpecification<TEntity, out TProperty> : ISpecification<TEntity>
        where TEntity : IAggregateRoot
    {
        IncludeNode GetIncludeNode();
    }
}
