using LibrarySystem.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Commands.UserCommands
{
    public class LoginCommand : IRequest<AuthDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
