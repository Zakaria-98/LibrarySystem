using LibrarySystem.Models;
using LibrarySystem.Commands.BookCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.BookCommands
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly IUnitOfWork _unitofwork;

        public AddBookHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request);
            var Book = await _unitofwork.Books.AddAsync(book);
            _unitofwork.Complete();
            return book;
        }
    }
}
