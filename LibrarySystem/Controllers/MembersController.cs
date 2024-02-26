using LibrarySystem.Dto;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using LibrarySystem.Queries.MemberQueries;
using LibrarySystem.Commands.MemberCommands;


namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetAlMembers()
        {
            var query = new GetAllMembersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetMembersById(int id)
        {
            var query = new GetMembersByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound("Wrong Id: " + id);

            return Ok(result);

        }


        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] MemberDto dto)
        {

            var Member = new Member
            {
                Name = dto.Name,
            };
            var command = new AddMemberCommand(Member);
            var result = await _mediator.Send(command);


            return Ok(result);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] MemberDto dto)
        {
            var memberquery = new GetMembersByIdQuery(id);
            var Member = await _mediator.Send(memberquery);
            if (Member == null)
                return NotFound("Wrong Id: " + id);

            Member.Name = dto.Name;
            var command = new UpdateMemberCommand(Member);
            var result = await _mediator.Send(command);


            return Ok("Updated done successfully");



        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var memberquery = new GetMembersByIdQuery(id);
            var Member = await _mediator.Send(memberquery);
            if (Member == null)
                return NotFound("Wrong Id: " + id);

            var command = new DeleteMemberCommand(Member);
            var result = await _mediator.Send(command);


            return Ok("Deleted done successfully");

        }
    }
}
