using DotNetCore.DDD.Template.Domain.DomainEvents;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 当一个query或者command有多个处理器时，只执行第一个处理器
/// </summary>
namespace DotNetCore.DDD.Template.Application.QueryHandlers
{
    public class TestQueryHandler : IRequestHandler<TestQueryInput, TestQueryOutput>
    {
        private readonly IMediator _mediator;

        public TestQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<TestQueryOutput> Handle(TestQueryInput request, CancellationToken cancellationToken)
        {
            //todo business

            await _mediator.Publish(new TestDomainEvent("江毅", "男"));
            Console.WriteLine("this is TestQueryHandler");
            return new TestQueryOutput { Name = request.Name };
        }
    }

    public class TestQueryHandler2 : IRequestHandler<TestQueryInput, TestQueryOutput>
    {
        private readonly IMediator _mediator;

        public TestQueryHandler2(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<TestQueryOutput> Handle(TestQueryInput request, CancellationToken cancellationToken)
        {
            //todo business

            await _mediator.Publish(new TestDomainEvent("江毅2", "男2"));
            Console.WriteLine("this is TestQueryHandler2");
            return new TestQueryOutput { Name = request.Name };
        }
    }
}
