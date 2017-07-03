using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.DTO
{
    public class UserDto
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
