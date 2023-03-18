using _0___SharedKernel.Domain.Entities;
using _0___SharedKernel.Domain.Repositories;
using _0___SharedKernel.Domain.Repositories.Specification;
using Microsoft.EntityFrameworkCore;

namespace _2___Infrastructure.SharedKernel.Repositories
{
    public class Repository<TEntity, TKey>
        : IRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot, IEntity<TKey>
    {
        protected ECommerceDbContext DbContext { get; set; }

        protected DbSet<TEntity> DbSet { get; }

        public Repository(ECommerceDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(ISpecification<TEntity> specification)
        {
            return await DbSet.Use(specification).ToArrayAsync();
        }

        public Task<TEntity> GetByIdAsync(TKey id)
        {
            return DbSet.FindAsync(id).AsTask();
        }

        public Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity> specification)
        {
            return DbSet.Use(specification)
                        .SingleOrDefaultAsync();
        }

        public Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity> specification)
        {
            return DbSet.Use(specification)
                        .FirstOrDefaultAsync();
        }

        public Task<int> CountAsync(ISpecification<TEntity> specification)
        {
            return DbSet.UseCriteria(specification)
                        .CountAsync();
        }

        public Task<bool> AnyAsync(ISpecification<TEntity> specification)
        {
            return DbSet.UseCriteria(specification)
                        .AnyAsync();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            var trackedEntity = DbSet.Local.FirstOrDefault(e => e.Id.Equals(entity.Id));
            if (trackedEntity != null)
            {
                DbContext.Entry(trackedEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                DbSet.Update(entity);
            }
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(TKey id)
        {
            var entity = DbSet.Find(id);
            Delete(entity);
        }

        public void Delete(ISpecification<TEntity> specification)
        {
            DbSet.UseCriteria(specification)
                 .ToList()
                 .ForEach(Delete);
        }

        public void DeleteRange(IEnumerable<TKey> ids)
        {
            DbSet.Where(entity => ids.Contains(entity.Id))
                 .ToList()
                 .ForEach(Delete);
        }
    }
}
