using DotNetCore.DDD.Template.Domain.DomainEvents;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCore.DDD.Template.Application.DomainEventHandlers
{
    public class TestDomainEventHandler : INotificationHandler<TestDomainEvent>
    {
        public async Task Handle(TestDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(string.Format("Name:{0},Sex:{1}", notification.Name, notification.Sex));
        }
    }
}
