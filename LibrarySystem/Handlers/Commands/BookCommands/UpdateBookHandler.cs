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
            _unitofwork.Books.Update(request.book);
            _unitofwork.Complete();

            return request.book;
        }
    }
}
