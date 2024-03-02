using LibrarySystem.Models;
using LibrarySystem.Commands.BookCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.BookCommands
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IUnitOfWork _unitofwork;

        public UpdateBookHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var Book = await _unitofwork.Books.GetByIdAsync(request.Id);
            if (Book == null)
                return null;

            var category = await _unitofwork.Categories.GetByIdAsync(request.CategoryId);
            if (category == null)
                return null;

            var book = new Book(request);

            _unitofwork.Books.Update(book);
            _unitofwork.Complete();

            return book;
        }
    }
}
