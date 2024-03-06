using LibrarySystem.Core.Commands.AuthCommands;
using LibrarySystem.Core.Dto;
using LibrarySystem.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Handlers.Commands.AuthCommands
{
    public class RegisterHandler 
    {
        /* :IRequestHandler<RegisterCommand, AuthDto>
          public readonly IAuthServices _authservice;
         public RegisterHandler(IAuthServices authservice)
         {
             _authservice = authservice;
         }

         public async Task<AuthDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
         {
             var result = await _authservice.RegisterAsync(request);
             return result;
         }*/
    }
}
