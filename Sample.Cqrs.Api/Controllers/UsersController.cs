using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Cqrs.Application.Features.User.GetCurrentUser;
using Sample.Cqrs.Application.Features.User.CreateUser;

namespace Sample.Cqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.Success)
                return BadRequest(response);

            return CreatedAtAction(nameof(Create),
                new { id = response.Result!.Id },
                response);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var response = await _mediator.Send(new GetCurrentUserRequest());
            return Ok(response);
        }

    }
}
