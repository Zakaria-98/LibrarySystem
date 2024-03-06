using LibrarySystem.Core.Commands.UserCommands;
using LibrarySystem.Core.Dto;
using LibrarySystem.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Handlers.Commands.UserCommands
{
    internal class LoginHandler : IRequestHandler<LoginCommand, AuthDto>
    {
        private readonly IUnitOfWork _unitofwork;

        public LoginHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<AuthDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitofwork.Users.LoginAsync(request);
            return result;
        }
    }
}
