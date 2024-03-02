using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Queries.BookQueries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<Book>>
    {
    }
}
