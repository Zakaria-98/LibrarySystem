using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Queries.BookQueries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id;
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
