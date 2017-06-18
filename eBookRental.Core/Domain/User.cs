using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace eBookRental.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Role { get; protected set; }

        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        protected User()
        {

        }

        public User(string email, string username, 
            string password, string salt, string role)
        {
            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Username = username;
            Password = password;
            Salt = salt;
            Role = role;
        }
    }
}
