using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.MemberCommands
{
    public class UpdateMemberCommand : IRequest<Member>
    {
        public Member member;

        public UpdateMemberCommand(Member member)
        {
            this.member = member;

        }
    }
}
