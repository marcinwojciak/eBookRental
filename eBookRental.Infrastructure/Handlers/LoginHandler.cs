using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Commands.Users;
using eBookRental.Infrastructure.Extensions;
using eBookRental.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Handlers
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IMemoryCache _cache;

        public LoginHandler(IUserService userService, IJwtService jwtService, IMemoryCache cache)
        {
            _userService = userService;
            _jwtService = jwtService;
            _cache = cache;
        }

        public async Task HandleAsync(Login command)
        {
            await _userService.LoginAsync(command.Email, command.Password);

            var user = await _userService.GetSingleAsync(command.Email);

            var jwt = _jwtService.CreateToken(command.Email, user.Role);

            _cache.SetJwt(command.TokenId, jwt);//14:18
        }
    }
}
