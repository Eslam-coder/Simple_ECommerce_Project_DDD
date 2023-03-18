using _0___SharedKernel.Domain.Entities;
using _0___SharedKernel.Domain.Repositories;

namespace _2___Infrastructure.SharedKernel.Repositories
{
    public class Repository<TEnity> : Repository<TEnity, Guid>, IRepository<TEnity>
        where TEnity : class, IAggregateRoot, IEntity
    {
        public Repository(ECommerceDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
