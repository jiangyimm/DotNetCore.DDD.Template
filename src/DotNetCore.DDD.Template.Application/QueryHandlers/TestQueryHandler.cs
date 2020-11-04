using DotNetCore.DDD.Template.Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.DDD.Template.Domain.Repositories;

/// <summary>
/// 当一个query或者command有多个处理器时，只执行第一个处理器
/// </summary>
namespace DotNetCore.DDD.Template.Application.QueryHandlers
{
    public class TestQueryHandler : IRequestHandler<TestQueryInput, TestQueryOutput>
    {
        private readonly IMediator _mediator;
        private readonly ITestCaseRepository _testCaseRepository;

        public TestQueryHandler(IMediator mediator, ITestCaseRepository testCaseRepository)
        {
            _mediator = mediator;
            _testCaseRepository = testCaseRepository;
        }
        public async Task<TestQueryOutput> Handle(TestQueryInput request, CancellationToken cancellationToken)
        {
            //todo business
            var res = await _testCaseRepository.AddAsync(new Domain.TestCaseAggregate.TestCase
            {

                Name = "123",
                Sort = 1,
                CodeContent = "哈哈哈哈",
                OperCode = "163",
                OperTime = DateTimeOffset.Now,
                TargetTestCaseGroup = new Domain.TestCaseAggregate.TestCaseGroup
                {
                    Name = "hhh",
                }
            });
            await _testCaseRepository.UnitOfWork.SaveEntitiesAsync();
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
