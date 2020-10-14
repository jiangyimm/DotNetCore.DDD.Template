using DotNetCore.DDD.Template.Application.CommandHandlers;
using DotNetCore.DDD.Template.Application.QueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DotNetCore.DDD.Template.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DDDController : ControllerBase
    {
        private readonly ILogger<DDDController> _logger;
        private readonly IMediator _mediator;

        public DDDController(ILogger<DDDController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<TestQueryOutput> Get([FromQuery] TestQueryInput input)
        {
            var result = await _mediator.Send(input);

            return result;
        }

        [HttpPost]
        public async Task<TestCommandOutput> Post([FromForm] TestCommandInput input)
        {
            var result = await _mediator.Send(input);

            return result;
        }
    }
}
