using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCore.DDD.Template.Infrastructure.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}