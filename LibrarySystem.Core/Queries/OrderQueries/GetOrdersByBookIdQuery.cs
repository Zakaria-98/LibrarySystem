using LibrarySystem.Models;
using MediatR;
using LibrarySystem.Dto;

namespace LibrarySystem.Queries.OrderQueries
{
    public class GetOrdersByBookIdQuery : IRequest<IEnumerable<DisplayOutput>>
    {
        public int BookId;
        public GetOrdersByBookIdQuery(int bookId)
        {
            BookId = bookId;    
        }
    }
}
