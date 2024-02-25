using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.MemberCommands
{
    public class DeleteMemberCommand : IRequest<Member>
    {
        public Member member;

        public DeleteMemberCommand(Member member)
        {
            this.member = member;

        }
    }
}
