using LibrarySystem.Models;
using LibrarySystem.Queries.BookQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.BookQueries
{
    public class GetBooksByCategoryHandler : IRequestHandler<GetBooksByCategoryQuery, IEnumerable<Book>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetBooksByCategoryHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<Book>> Handle(GetBooksByCategoryQuery request, CancellationToken cancellationToken)
        {

            var category = await _unitofwork.Categories.GetByIdAsync(request.Categoryid);
            if (category == null)
                return null;

            var books = await _unitofwork.Books.GetListAsync(c => c.CategoryId == request.Categoryid);

            return books;
        }
    }
}
