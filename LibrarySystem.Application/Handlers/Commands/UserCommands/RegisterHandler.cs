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
    public class RegisterHandler : IRequestHandler<RegisterCommand, AuthDto>
    {

        private readonly IUnitOfWork _unitofwork;

        public RegisterHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<AuthDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
         {
             var result = await _unitofwork.Users.RegisterAsync(request);
             return result;
         }
    }
}
