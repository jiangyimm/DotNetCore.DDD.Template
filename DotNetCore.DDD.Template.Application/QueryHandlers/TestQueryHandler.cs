using DotNetCore.DDD.Template.Domain.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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

            return new TestQueryOutput { Name = request.Name };
        }
    }
}
