using LibrarySystem.Models;
using LibrarySystem.Commands.MemberCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.MemberCommands
{
    public class AddMemberHandler : IRequestHandler<AddMemberCommand, Member>
    {
        private readonly IUnitOfWork _unitofwork;

        public AddMemberHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Member> Handle(AddMemberCommand request, CancellationToken cancellationToken)
        {
            var member = new Member(request);
            var Member = await _unitofwork.Members.AddAsync(member);
            _unitofwork.Complete();
            return member;
        }
    }
}
