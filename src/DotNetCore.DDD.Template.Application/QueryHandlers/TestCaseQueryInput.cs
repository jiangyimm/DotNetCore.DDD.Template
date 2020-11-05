using MediatR;
using System.Collections.Generic;

namespace DotNetCore.DDD.Template.Application.QueryHandlers
{
    public class TestCaseQueryInput : IRequest<IEnumerable<TestCaseQueryOutput>>
    {
        public string SearchKey { get; set; }
    }
}
