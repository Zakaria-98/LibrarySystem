using LibrarySystem.Core.Commands.UserCommands;
using LibrarySystem.Core.Dto;
using LibrarySystem.Core.Models;
using LibrarySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<AuthDto> RegisterAsync(RegisterCommand model);
        Task<AuthDto> LoginAsync(LoginCommand model);

    }
}
