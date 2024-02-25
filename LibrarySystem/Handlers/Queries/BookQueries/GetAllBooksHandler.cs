using LibrarySystem.Models;
using LibrarySystem.Queries.BookQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.BookQueries
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetAllBooksHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var Books = await _unitofwork.Books.GetAllAsync();
            return Books;
        }
    }
}
