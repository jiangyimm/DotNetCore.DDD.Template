using System.Threading.Tasks;
using System.Threading;
using DotNetCore.DDD.Template.Infrastructure.Abstractions;

namespace DotNetCore.DDD.Template.Infrastructure.Core
{
    public interface IRepository<TEntity>
    where TEntity : Entity, IAggregationRoot
    {
        IUnitOfWork UnitOfWork { get; }
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        bool Remove(TEntity entity);
        Task<bool> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
    }

    public interface IRepository<TEntity, TKey> : IRepository<TEntity>
    where TEntity : Entity<TKey>, IAggregationRoot
    {
        bool Remove(TKey id);
        Task<bool> RemoveAsync(TKey id, CancellationToken cancellationToken = default);
        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default);
    }
}