using DotNetCore.DDD.Template.Domain.DomainEvents;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 当一个领域事件有多个处理器时，是按代码顺序依次执行的
/// </summary>
namespace DotNetCore.DDD.Template.Application.DomainEventHandlers
{
    public class TestDomainEventHandler : INotificationHandler<TestDomainEvent>
    {
        public async Task Handle(TestDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(string.Format("Name:{0},Sex:{1}", notification.Name, notification.Sex));
        }
    }

    public class TestDomainEventHandler2 : INotificationHandler<TestDomainEvent>
    {
        public async Task Handle(TestDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(string.Format("Name2:{0},Sex2:{1}", notification.Name, notification.Sex));
        }
    }

}
