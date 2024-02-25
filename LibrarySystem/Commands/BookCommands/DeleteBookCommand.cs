using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.BookCommands
{
    public class DeleteBookCommand : IRequest<Book>
    {
        public Book book;

        public DeleteBookCommand(Book book)
        {
            this.book = book;

        }
    }
}
