using LibrarySystem.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Commands.AuthCommands
{
    public class RegisterCommand : IRequest<AuthDto>
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
