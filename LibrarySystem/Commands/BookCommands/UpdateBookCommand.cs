using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.BookCommands
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public string Title { get; set; }

        public int AllQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int CategoryId { get; set; }

        public int Id { get; set; }

    }
}
