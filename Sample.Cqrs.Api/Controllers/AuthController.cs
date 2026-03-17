using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Cqrs.Application.Features.User.Logout;
using Sample.Cqrs.Application.Features.User.Login;
using Sample.Cqrs.Application.Abstractions.Mediator;

namespace Sample.Cqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _mediator.Send(request);

            //if (!response.Success)
            //    return Unauthorized(response);

            return Ok(response);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var response = await _mediator.Send(new LogoutRequest());

            return Ok(response);
        }
    }
}
