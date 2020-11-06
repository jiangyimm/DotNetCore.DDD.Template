using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.DDD.Template.Domain.Repositories;
using DotNetCore.DDD.Template.Domain.TestCaseAggregate;
using DotNetCore.DDD.Template.Domain.Events;

namespace DotNetCore.DDD.Template.Application.CommandHandlers
{
    public class TestCaseCommandHandler : IRequestHandler<TestCaseCreateInput, TestCaseCreateOutput>
    {
        private readonly IMediator _mediator;
        private readonly ITestCaseRepository _testCaseRepository;

        public TestCaseCommandHandler(ITestCaseRepository testCaseRepository, IMediator mediator)
        {
            _testCaseRepository = testCaseRepository;
            _mediator = mediator;
        }

        public async Task<TestCaseCreateOutput> Handle(TestCaseCreateInput request, CancellationToken cancellationToken)
        {
            var testCaseGroup = new TestCaseGroup("group1", 1, "162", DateTimeOffset.Now);
            //var testCase = new TestCase(request.Name, 1, "😂", "162", DateTimeOffset.Now, testCaseGroup);
            var testCaseValueObject = new TestCaseValueObject("feild1", true);
            var testCase = new TestCase(request.Name, 1, "😂", "162", DateTimeOffset.Now, testCaseValueObject);
            testCase.SetTargetTestCaseGroup(testCaseGroup);

            await _testCaseRepository.AddAsync(testCase, cancellationToken);
            await _testCaseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            await _mediator.Publish(new TestCaseCreateDomainEvent(testCase), cancellationToken);

            return new TestCaseCreateOutput
            {
                Id = testCase.Id,
                Name = testCase.Name
            };
        }
    }
}
