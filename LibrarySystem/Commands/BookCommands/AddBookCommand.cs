using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.BookCommands
{
    public class AddBookCommand : IRequest<Book>
    {
        public Book book;

        public AddBookCommand(Book book)
        {
            this.book = book;

        }
    }
}
