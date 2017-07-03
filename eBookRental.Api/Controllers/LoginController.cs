using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Commands.Users;
using eBookRental.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookRental.Api.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IMemoryCache _cache;

        public LoginController(IMemoryCache cache, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Login command)
        {
            command.TokenId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Ok(jwt);
        }
    }
}
