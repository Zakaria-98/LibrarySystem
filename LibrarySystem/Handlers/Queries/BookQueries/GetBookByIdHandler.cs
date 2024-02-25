using LibrarySystem.Models;
using LibrarySystem.Queries.BookQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.BookQueries
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetBookByIdHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {

            var Book = await _unitofwork.Books.GetByIdAsync(request.Id);
            if (Book == null)
                return null;

            return Book;
        }
    }
}
