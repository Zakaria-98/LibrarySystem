using LibrarySystem.Models;
using MediatR;
using LibrarySystem.Dto;

namespace LibrarySystem.Queries.OrderQueries
{
    public class GetOrdersByMemberIdQuery : IRequest<IEnumerable<DisplayOutput>>
    {
        public int MemberId;
        public GetOrdersByMemberIdQuery(int memberId)
        {
            MemberId = memberId;    
        }
    }
}
