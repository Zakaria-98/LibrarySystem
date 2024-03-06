using LibrarySystem.Core.Commands.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;



        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]

        public async Task<IActionResult> RegisterUser([FromBody] RegisterCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = model;
            var result = await _mediator.Send(command);
           
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);

        }

        [HttpPost("login")]

        public async Task<IActionResult> LoginUser([FromBody] LoginCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = model;
            var result = await _mediator.Send(query);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);

        }
    }
}
