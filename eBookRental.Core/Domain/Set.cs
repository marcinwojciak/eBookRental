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
        public bool IsAvailable { get; set; }
        public ICollection<Rental> Rentals { get; set; }

        protected Set()
        {

        }

        public Set(Book book, bool isAvailable)
        {
            Id = Guid.NewGuid();
            Book = book;
            IsAvailable = isAvailable;
            Rentals = new List<Rental>();
        }                                
    }
}
