using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.RestorationCommands
{
    public class DeleteRestorationCommand : IRequest<bool>
    {
        public int Id;
        public DeleteRestorationCommand(int id)
        {
            Id = id;
        }
    }
}
