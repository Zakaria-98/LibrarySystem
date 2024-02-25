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

            var books = await _unitofwork.Books.GetListAsync(c => c.CategoryId == request.Categoryid,
            g => new Book
            {
                Id = g.Id,
                Title = g.Title,
                CategoryId = g.CategoryId,
                AllQuantity = g.AllQuantity,
                AvailableQuantity = g.AvailableQuantity


            });

            return books;
        }
    }
}
