using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace DotNetCore.DDD.Template.Infrastructure.Core
{
    public class EFContext : DbContext, IUnitOfWork
    {
        //protected readonly IMediator _mediator;
        public EFContext(DbContextOptions options /*, IMediator mediator*/) : base(options)
        {
            //_mediator = mediator;
        }

        #region IUnitOfWork
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            //TODO publish domain event
            //_mediator.Publish(this);
            return result > 0;
        }
        #endregion


    }
}