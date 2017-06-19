using eBookRental.Infrastructure.Commands.Users;
using eBookRental.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookRental.Api.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //GET
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.GetSingleAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetSingleAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        //POST
        [HttpPost]
        public async Task Create([FromBody]CreateUser command)
            => await _userService.RegisterAsync(command.Email, command.Username, command.FullName, command.Password, command.Role);
    }
}
