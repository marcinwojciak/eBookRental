﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.Commands.Users
{
    public class CreateUser : ICommand
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string IdentityCard { get; set; }
        public string Mobile { get; set; }
    }
}
