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

        public string IdentityCard { get; protected set; }
        public string Mobile { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        protected User()
        {

        }

        public User(Guid id, string email, string username, string fullName,
            string password, string salt, string role, string identityCard, string mobile)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;

            SetEmail(email);
            SetUsername(username);
            SetFullName(username); 
            SetPassword(password, salt);
            SetRole(role);
            SetIdentityCard(identityCard);
            SetMobileNumber(mobile);
        }

        private void SetMobileNumber(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
            {
                throw new Exception("Given mobile number is invalid.");
            }

            if (mobile.Length != 9)
            {
                throw new Exception("Given mobile number is invalid.");
            }

            Mobile = mobile;
        }

        private void SetIdentityCard(string identityCard)
        {
            if (string.IsNullOrWhiteSpace(identityCard))
            {
                throw new Exception("Given card number is invalid.");
            }

            IdentityCard = identityCard;
        }

        private void SetRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new Exception("Role is invalid.");
            }
            
            Role = role;
        }

        private void SetPassword(string password, string salt)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is invalid.");
            }

            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Salt cannot be empty.");
            }

            Password = password;
            Salt = salt;
        }

        private void SetFullName(string fullName)
        {
            if (!NameRegex.IsMatch(fullName))
            {
                throw new Exception("FullName is invalid.");
            }

            if (String.IsNullOrEmpty(fullName))
            {
                throw new Exception("FullName is invalid.");
            }

            FullName = fullName.ToLowerInvariant();
        }

        private void SetUsername(string username)
        {
            if (!NameRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid.");
            }

            if (String.IsNullOrEmpty(username))
            {
                throw new Exception("Username is invalid.");
            }

            Username = username.ToLowerInvariant();
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is invalid.");
            }

            Email = email.ToLowerInvariant();
        }
    }
}
