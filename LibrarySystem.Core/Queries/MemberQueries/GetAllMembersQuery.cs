using LibrarySystem.Models;
using MediatR;


namespace LibrarySystem.Queries.MemberQueries
{
    public class GetAllMembersQuery : IRequest<IEnumerable<Member>>
    {
    }
}
