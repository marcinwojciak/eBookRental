﻿using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Commands.Users;
using eBookRental.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Email, command.Username, 
                command.FullName, command.Password, command.Role);
        }
    }
}
