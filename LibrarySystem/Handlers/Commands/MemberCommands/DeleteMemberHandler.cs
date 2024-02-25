using LibrarySystem.Models;
using LibrarySystem.Commands.MemberCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.MemberCommands
{
    public class DeleteMemberHandler : IRequestHandler<DeleteMemberCommand, Member>
    {
        private readonly IUnitOfWork _unitofwork;

        public DeleteMemberHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Member> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            _unitofwork.Members.Delete(request.member);
            _unitofwork.Complete();

            return request.member;
        }
    }
}
