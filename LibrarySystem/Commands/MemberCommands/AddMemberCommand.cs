using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.MemberCommands
{
    public class AddMemberCommand : IRequest<Member>
    {
        public Member member;

        public AddMemberCommand(Member member)
        {
            this.member = member;

        }
    }
}
