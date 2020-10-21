using MediatR;

namespace DotNetCore.DDD.Template.Application.QueryHandlers
{
    public class TestQueryInput : IRequest<TestQueryOutput>
    {
        public string Name { get; set; }
    }
}
