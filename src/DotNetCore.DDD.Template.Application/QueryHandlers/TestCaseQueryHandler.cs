using DotNetCore.DDD.Template.Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.DDD.Template.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;


/// <summary>
/// 当一个query或者command有多个处理器时，只执行第一个处理器
/// </summary>
namespace DotNetCore.DDD.Template.Application.QueryHandlers
{
    public class TestCaseQueryHandler : IRequestHandler<TestCaseQueryInput, IEnumerable<TestCaseQueryOutput>>
    {
        private readonly ITestCaseRepository _testCaseRepository;

        public TestCaseQueryHandler(ITestCaseRepository testCaseRepository)
        {
            _testCaseRepository = testCaseRepository;
        }
        public async Task<IEnumerable<TestCaseQueryOutput>> Handle(TestCaseQueryInput request, CancellationToken cancellationToken)
        {
            //TODO business
            Console.WriteLine("this is TestQueryHandler");

            var testCases = await _testCaseRepository.Query(request.SearchKey);

            return testCases.Select(p => new TestCaseQueryOutput
            {
                Id = p.Id,
                Name = p.Name
            });
        }
    }

    public class TestCaseQueryHandler2 : IRequestHandler<TestCaseQueryInput, IEnumerable<TestCaseQueryOutput>>
    {
        private readonly ITestCaseRepository _testCaseRepository;

        public TestCaseQueryHandler2(ITestCaseRepository testCaseRepository)
        {
            _testCaseRepository = testCaseRepository;
        }
        public async Task<IEnumerable<TestCaseQueryOutput>> Handle(TestCaseQueryInput request, CancellationToken cancellationToken)
        {
            //TODO business
            Console.WriteLine("this is TestQueryHandler2");

            var testCases = await _testCaseRepository.Query(request.SearchKey);

            return testCases.Select(p => new TestCaseQueryOutput
            {
                Id = p.Id,
                Name = p.Name
            });
        }
    }
}
