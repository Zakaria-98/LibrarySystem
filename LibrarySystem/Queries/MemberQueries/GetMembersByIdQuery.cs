using LibrarySystem.Models;
using MediatR;


namespace LibrarySystem.Queries.MemberQueries
{
    public class GetMembersByIdQuery : IRequest<Member>
    {
        public int Id;
        public GetMembersByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
