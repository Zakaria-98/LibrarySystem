using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.BookCommands
{
    public class DeleteBookCommand : IRequest<Book>
    {
        public int Id;

        public DeleteBookCommand(int id)
        {
            Id = id;

        }
    }
}
