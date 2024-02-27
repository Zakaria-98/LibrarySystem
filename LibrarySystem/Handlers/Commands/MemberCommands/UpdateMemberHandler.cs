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

            var member = new Member(request);
            _unitofwork.Members.Update(member);
            _unitofwork.Complete();

            return  member;
        }
    }
}
