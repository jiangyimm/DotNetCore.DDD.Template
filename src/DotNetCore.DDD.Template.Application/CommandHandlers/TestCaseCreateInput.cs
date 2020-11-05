using MediatR;

namespace DotNetCore.DDD.Template.Application.CommandHandlers
{
    public class TestCaseCreateInput : IRequest<TestCaseCreateOutput>
    {
        public string Name { get; set; }
    }
}
