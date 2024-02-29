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
            var member = await _unitofwork.Members.GetByIdAsync(request.Id);
            if (member == null)
                return null;

            member.Name = request.Name;
            _unitofwork.Members.Update(member);
            _unitofwork.Complete();

            return  member;
        }
    }
}
