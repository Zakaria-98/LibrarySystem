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
            var member = _memberService.AddMember(dto);
            return Ok(member);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] MemberDto dto)
        {
            var member = _memberService.GetMembersById(id);

            if (member == null)
                return NotFound("Wrong Id: " + id);

           member=_memberService.UpdateMember(id, dto);
            return Ok(member);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _memberService.GetMembersById(id);

            if (member == null)
                return NotFound("Wrong Id: " + id);

            member = await _memberService.DeleteMember(id);
            return Ok(member);

        }
    }
}
