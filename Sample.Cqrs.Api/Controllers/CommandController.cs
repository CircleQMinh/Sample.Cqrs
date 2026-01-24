using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Cqrs.Application.Features.Command.Commands.CreateCommand;

namespace Sample.Cqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommandRequest command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}
