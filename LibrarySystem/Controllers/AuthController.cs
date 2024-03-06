using LibrarySystem.Core.Commands.AuthCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
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
    }
}
