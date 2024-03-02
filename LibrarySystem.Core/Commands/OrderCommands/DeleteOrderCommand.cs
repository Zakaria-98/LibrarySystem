using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.OrderCommands
{
    public class DeleteOrderCommand:IRequest<bool>
    {
        public int Id;
        public DeleteOrderCommand(int id )
        {
            this.Id = id;


        }
    }
}
