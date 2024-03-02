using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.RestorationCommands
{
    public class AddRestorationCommand : IRequest<bool>
    {
        public int Id;
        public AddRestorationCommand(int id)
        {
            Id = id;
        }

    }
}
