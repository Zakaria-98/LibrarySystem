using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.MemberCommands
{
    public class UpdateMemberCommand : IRequest<Member>
    {
        
        public string Name { get; set; }

        public int Id { get; set; }

    }
}
