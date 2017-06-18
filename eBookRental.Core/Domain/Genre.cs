using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Core.Domain
{
    public class Genre
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        public IEnumerable<Book> Books { get; protected set; }

        protected Genre()
        {

        }

        public Genre(string name)
        {
            Id = Guid.NewGuid();
            Name = name.ToLowerInvariant();

            Books = new List<Book>();
        }
    }
}
