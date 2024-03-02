using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.MemberCommands
{
    public class AddMemberCommand : IRequest<Member>
    {
        public string Name { get; set; }

    }
}
