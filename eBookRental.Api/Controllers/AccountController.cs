using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Commands.Users;
using eBookRental.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookRental.Api.Controllers
{

    public class AccountController : ApiController
    {
        private readonly IJwtService _jwtService;

        public AccountController(ICommandDispatcher commandDispatcher, IJwtService jwtService)
            : base(commandDispatcher)
        {
            _jwtService = jwtService;
        }

        [HttpGet]
        [Route("token")]
        public IActionResult Get()
        {
            var token = _jwtService.CreateToken("tomek@domain.com", "user");

            return Ok(token);
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
