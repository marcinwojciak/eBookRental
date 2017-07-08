using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Commands.Users;
using eBookRental.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eBookRental.Api.Controllers
{
    [Route("users")]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _userService = userService;
        }

        //GET
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.GetSingleAsync(id);

            NotFoundResult(user);

            return Ok(user);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetSingleAsync(email);

            return Ok(user);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateUser command)
        {
            if(command == null)
            {
                return BadRequest();
            }

            await CommandDispatcher.DispatchAsync(command);

            return Created($"users/{command.Email}", new object());
        }
    }
}
