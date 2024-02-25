using LibrarySystem.Commands.MemberCommands;
using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.MemberQueries;
using LibrarySystem.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class MemberService:IMemberService
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;
        private readonly IMediator _mediator;


        public MemberService(ApplicationDbContext context, IUnitOfWork unitofwork, IMediator mediator)
        {
            _context = context;
            _unitofwork = unitofwork;
            _mediator = mediator;
        }


        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            var query = new GetAllMembersQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        public async Task<Member> GetMembersById(int id)
        {
            var query = new GetMembersByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
                return null;

            return result;

        }

        public async Task<Member> AddMember(Member member)
        {
            var command = new AddMemberCommand(member);
            var result = await _mediator.Send(command);


            return result;
        }

        public async Task<Member> DeleteMember(Member member)
        {
            var command = new DeleteMemberCommand(member);
            var result = await _mediator.Send(command);


            return result;
        }


        public async Task<Member> UpdateMember(Member member)
        {
            var command = new UpdateMemberCommand(member);
            var result = await _mediator.Send(command);


            return result;
        }
    }
}
