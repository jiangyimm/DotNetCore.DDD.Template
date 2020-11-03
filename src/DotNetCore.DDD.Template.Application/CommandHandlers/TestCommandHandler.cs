using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.DDD.Template.Domain.Repositories;

namespace DotNetCore.DDD.Template.Application.CommandHandlers
{
    public class TestCommandHandler : IRequestHandler<TestCommandInput, TestCommandOutput>
    {
        private readonly ITestCaseRepository _testCaseRepository;

        public TestCommandHandler(ITestCaseRepository testCaseRepository)
        {
            _testCaseRepository = testCaseRepository;
        }

        public async Task<TestCommandOutput> Handle(TestCommandInput request, CancellationToken cancellationToken)
        {
            return new TestCommandOutput
            {
                Name = request.Name,
                Sex = request.Sex
            };
        }
    }
}
