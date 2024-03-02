using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.OrderCommands
{
    public class IsOrderRestoredCommands : IRequest<bool>
    {
        public int Id;
        public IsOrderRestoredCommands(int id)
        {
            this.Id = id;


        }
    }
}
