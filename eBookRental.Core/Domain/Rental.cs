using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Core.Domain
{
    public class Rental
    {
        public Guid Id { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public Guid SetId { get; protected set; }
        public Set Set { get; protected set; }
        public string Status { get; protected set; }

        public DateTime RentalDate { get; protected set; }
        public DateTime? ReturnedDate { get; protected set; }
        
        public Rental()
        {
            Id = Guid.NewGuid();
        }
    }
}
