using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAlMembers()
        {
            var members = await _memberService.GetAllMembers();
            return Ok(members);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetMembersById(int id)
        {
            var member = await _memberService.GetMembersById(id);

            if (member == null)
                return NotFound("Wrong Id: " + id);

            return Ok(member);

        }


        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] MemberDto dto)
        {
            var Member = new Member
            {
                Name = dto.Name,
            };
            var member = _memberService.AddMember(Member);
            return Ok(member);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] MemberDto dto)
        {
            var Member = await _memberService.GetMembersById(id);

            if (Member == null)
                return NotFound("Wrong Id: " + id);

            Member.Name = dto.Name;

           var member= _memberService.UpdateMember(Member);
            return Ok(member);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var Member = await _memberService.GetMembersById(id);

            if (Member == null)
                return NotFound("Wrong Id: " + id);

           var  member =   _memberService.DeleteMember(Member);
            return Ok(member);

        }
    }
}
