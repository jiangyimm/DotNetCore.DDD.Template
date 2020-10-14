using MediatR;

namespace DotNetCore.DDD.Template.Application.CommandHandlers
{
    public class TestCommandInput : IRequest<TestCommandOutput>
    {
        public string Name { get; set; }
        public string Sex { get; set; }
    }
}
