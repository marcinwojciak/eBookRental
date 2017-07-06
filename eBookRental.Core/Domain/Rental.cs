using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Core.Domain
{
    public class Rental
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Guid SetId { get; protected set; }
        public Set Set { get; protected set; }
        public RentalStatus Status { get; set; }

        public DateTime RentalDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

        protected Rental()
        {

        }

        public Rental(RentalStatus status, Guid setId, Guid userId, DateTime rentalDate)
        {
            Id = Guid.NewGuid();

            Status = status;
            SetId = setId;
            UserId = userId;
            RentalDate = rentalDate;
        }
    }
}
