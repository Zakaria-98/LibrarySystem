using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.MemberCommands
{
    public class DeleteMemberCommand : IRequest<Member>
    {
        public int Id;

        public DeleteMemberCommand(int id)
        {
            this.Id = id;

        }
    }
}
