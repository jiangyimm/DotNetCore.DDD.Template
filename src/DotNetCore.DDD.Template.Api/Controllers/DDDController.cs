using DotNetCore.DDD.Template.Application.CommandHandlers;
using DotNetCore.DDD.Template.Application.QueryHandlers;
using DotNetCore.DDD.Template.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCore.DDD.Template.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DDDController : ControllerBase
    {
        private readonly ILogger<DDDController> _logger;
        private readonly IMediator _mediator;
        private readonly ITestCaseRepository _testCaseRepository;

        public DDDController(ILogger<DDDController> logger, IMediator mediator, ITestCaseRepository testCaseRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _testCaseRepository = testCaseRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TestCaseQueryOutput>> Query([FromQuery] TestCaseQueryInput input)
        {
            var result = await _mediator.Send(input);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<dynamic> GetAggregation([FromRoute] long id)
        {
            var result = await _testCaseRepository.GetAggregationAsync(id);
            if (result == null)
                return null;
            return new
            {
                result.Id,
                result.Name,
                result.CodeContent,
                TestCaseGroup = new
                {
                    result.TargetTestCaseGroup.Id,
                    result.TargetTestCaseGroup.Name
                }
            };
        }

        [HttpPost]
        public async Task<TestCaseCreateOutput> Post([FromForm] TestCaseCreateInput input)
        {
            var result = await _mediator.Send(input);

            return result;
        }
    }
}
