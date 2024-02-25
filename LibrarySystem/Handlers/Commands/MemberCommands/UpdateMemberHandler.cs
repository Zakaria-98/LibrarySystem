using LibrarySystem.Models;
using LibrarySystem.Commands.MemberCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.MemberCommands
{
    public class UpdateMemberHandler : IRequestHandler<UpdateMemberCommand, Member>
    {
        private readonly IUnitOfWork _unitofwork;

        public UpdateMemberHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Member> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            _unitofwork.Members.Update(request.member);
            _unitofwork.Complete();

            return request.member;
        }
    }
}
