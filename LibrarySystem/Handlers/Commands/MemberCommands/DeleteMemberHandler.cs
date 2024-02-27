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
            var Member = await _unitofwork.Members.GetByIdAsync(request.Id);
            if (Member == null)
                return null;


            _unitofwork.Members.Delete(Member);
            _unitofwork.Complete();

            return Member;
        }
    }
}
