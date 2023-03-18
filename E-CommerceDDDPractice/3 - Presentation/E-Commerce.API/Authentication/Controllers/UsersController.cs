using E_Commerce.API.Authentication.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Authentication.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
