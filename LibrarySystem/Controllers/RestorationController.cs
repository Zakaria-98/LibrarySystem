using LibrarySystem.Dto;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using LibrarySystem.Queries.RestorationQuiries;
using LibrarySystem.Commands.RestorationCommands;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestorationController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public RestorationController(ApplicationDbContext context ,  IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllRestorations()
        {
            var query = new GetAllRestorationsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddRestoration(int id)
        {
            var command = new AddRestorationCommand(id);
            var result = await _mediator.Send(command);
            if (result == false)
                return BadRequest(" Restoration  wrong! please try again");

            return Ok(" Restoration done successfully");


        }


        [HttpDelete]
        public async Task<IActionResult> DeleteRestoration(int id)
        {
            var command = new DeleteRestorationCommand(id);
            var result = await _mediator.Send(command);
            if (result == false)
                return BadRequest(" Restoration  wrong! please try again");

            return Ok(" Restoration done successfully");


        }


    }
}
