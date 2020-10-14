using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCore.DDD.Template.Application.CommandHandlers
{
    public class TestCommandHandler : IRequestHandler<TestCommandInput, TestCommandOutput>
    {
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
