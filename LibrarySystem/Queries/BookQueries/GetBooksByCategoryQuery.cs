using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Queries.BookQueries
{
    public class GetBooksByCategoryQuery : IRequest<IEnumerable<Book>>
    {
        public int Categoryid;
        public GetBooksByCategoryQuery(int id)
        {
            Categoryid = id;
        }
    }
}
