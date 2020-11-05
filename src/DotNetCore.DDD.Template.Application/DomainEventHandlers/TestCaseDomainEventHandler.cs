using DotNetCore.DDD.Template.Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 当一个领域事件有多个处理器时，是按代码顺序依次执行的
/// </summary>
namespace DotNetCore.DDD.Template.Application.DomainEventHandlers
{
    public class TestCaseCreateDomainEventHandler : INotificationHandler<TestCaseCreateDomainEvent>
    {
        public async Task Handle(TestCaseCreateDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(string.Format("Id:{0},Name:{1}", notification.TestCase.Id, notification.TestCase.Name));
        }
    }

    public class TestCaseCreateDomainEventHandler2 : INotificationHandler<TestCaseCreateDomainEvent>
    {
        public async Task Handle(TestCaseCreateDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(string.Format("Id2:{0},Name2:{1}", notification.TestCase.Id, notification.TestCase.Name));
        }
    }

}
