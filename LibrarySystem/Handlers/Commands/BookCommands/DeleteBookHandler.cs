using LibrarySystem.Models;
using LibrarySystem.Commands.BookCommands;
using LibrarySystem.UnitOfWork;
using MediatR;
using LibrarySystem.Commands.CategoryCommands;

namespace LibrarySystem.Handlers.Commands.BookCommands
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, Book>
    {
        private readonly IUnitOfWork _unitofwork;

        public DeleteBookHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Book> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            _unitofwork.Books.Delete(request.book);
            _unitofwork.Complete();

            return request.book;
        }
    }
}
