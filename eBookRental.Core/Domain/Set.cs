using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Core.Domain
{
    public class Set
    {
        public Guid Id { get; protected set; }
        public Guid BookId { get; protected set; }
        public Book Book { get; protected set; }
        public bool IsAvailable { get; protected set; }
        public IEnumerable <Rental> Rentals { get; protected set; }

        public Set()
        {
            Id = Guid.NewGuid();
            Rentals = new List<Rental>();
        }
    }
}
