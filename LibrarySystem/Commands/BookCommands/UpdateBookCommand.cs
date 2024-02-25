using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.BookCommands
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public Book book;

        public UpdateBookCommand(Book book)
        {
            this.book = book;

        }
    }
}
