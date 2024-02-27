using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.BookCommands
{
    public class AddBookCommand : IRequest<Book>
    {
        public string Title { get; set; }
        public int AllQuantity { get; set; }

        public int CategoryId { get; set; }


    }
}
