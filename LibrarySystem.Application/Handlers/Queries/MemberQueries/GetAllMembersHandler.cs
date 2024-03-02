using LibrarySystem.Models;
using LibrarySystem.Queries.MemberQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.MemberQueries
{
    public class GetAllMembersHandler : IRequestHandler<GetAllMembersQuery, IEnumerable<Member>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetAllMembersHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<Member>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var Members = await _unitofwork.Members.GetAllAsync();
            return Members;
        }
    }
}
