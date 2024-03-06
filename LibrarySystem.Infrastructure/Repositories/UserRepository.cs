using LibrarySystem.Core.Commands.UserCommands;
using LibrarySystem.Core.Dto;
using LibrarySystem.Core.Models;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Helpers;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        private readonly JWT _jwt;
        public UserRepository(ApplicationDbContext context, UserManager<User> usermanager, RoleManager<IdentityRole> rolemanager, IOptions<JWT> jwt) : base(context)
        {
            _context = context;
            _userManager = usermanager;
            _rolemanager = rolemanager;
            _jwt = jwt.Value;

        }




        public async Task<AuthDto> RegisterAsync(RegisterCommand model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthDto { Message = "Email is already registered" };

            if (await _userManager.FindByNameAsync(model.UserName) is not null)
                return new AuthDto { Message = "Username is already registered!" };

            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,

            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthDto { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthDto
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };
        }

        public async Task<AuthDto> LoginAsync(LoginCommand model)
        {
            var AuthDto = new AuthDto();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                AuthDto.Message = "Email or Password is incorrect!";
                return AuthDto;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            AuthDto.IsAuthenticated = true;
            AuthDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            AuthDto.Email = user.Email;
            AuthDto.Username = user.UserName;
            AuthDto.ExpiresOn = jwtSecurityToken.ValidTo;
            AuthDto.Roles = rolesList.ToList();

            return AuthDto;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }


    }
}
