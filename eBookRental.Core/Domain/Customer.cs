using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Core.Domain
{
    public class Customer
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string IdentityCard { get; protected set; }
        public string Mobile { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }

        protected Customer()
        {

        }

        public Customer(string firstName, 
            string lastName, string email, string mobile)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email.ToLowerInvariant();
            Mobile = mobile;
        }
    }
}
