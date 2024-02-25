using LibrarySystem.Models;
using LibrarySystem.Queries.MemberQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.MemberQueries
{
    public class GetMembersByIdHandler : IRequestHandler<GetMembersByIdQuery,Member>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetMembersByIdHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Member> Handle(GetMembersByIdQuery request, CancellationToken cancellationToken)
        {
            var Member = await _unitofwork.Members.GetByIdAsync(request.Id);
            if (Member == null)
                return null;

            return Member;
        }
    }
}
