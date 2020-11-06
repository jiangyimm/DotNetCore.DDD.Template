using System.Threading;
using System.Threading.Tasks;
using DotNetCore.DDD.Template.Infrastructure.Abstractions;

namespace DotNetCore.DDD.Template.Infrastructure.Core
{
    public abstract class Repository<TEntity, TDbContext>
    : IRepository<TEntity>
    where TEntity : Entity, IAggregationRoot
    where TDbContext : EFContext
    {
        protected virtual TDbContext DbContext { get; set; }

        public Repository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public virtual IUnitOfWork UnitOfWork => DbContext;

        public virtual TEntity Add(TEntity entity)
        {
            return DbContext.Add(entity).Entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var result = await DbContext.AddAsync(entity, cancellationToken);
            return result.Entity;
        }

        public virtual bool Remove(TEntity entity)
        {
            DbContext.Remove(entity);
            return true;
        }

        public Task<bool> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Remove(entity));
        }

        public TEntity Update(TEntity entity)
        {
            return DbContext.Update(entity).Entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Update(entity));
        }
    }

    public abstract class Repository<TEntity, TKey, TDbContext>
    : Repository<TEntity, TDbContext>, IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>, IAggregationRoot
    where TDbContext : EFContext
    {
        protected Repository(TDbContext dbContext) : base(dbContext)
        {
        }

        public virtual TEntity Get(TKey id)
        {
            return DbContext.Find<TEntity>(id);
        }

        public virtual async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await DbContext.FindAsync<TEntity>(id, cancellationToken);
        }

        public virtual bool Remove(TKey id)
        {
            var entity = Get(id);
            if (entity == null)
            {
                throw new System.Exception("entity not found");
                //eturn false;
            }
            DbContext.Remove(entity);
            return true;
        }

        public virtual async Task<bool> RemoveAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = GetAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new System.Exception("entity not found");
                //eturn false;
            }
            DbContext.Remove(entity);
            return true;
        }
    }
}