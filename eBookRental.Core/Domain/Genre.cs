using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Core.Domain
{
    public class Genre
    {
        public Guid Id { get; protected set; }
        public GenreType Name { get; protected set; }

        public ICollection<Book> Books { get; protected set; }

        protected Genre()
        {

        }

        public Genre(GenreType name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Books = new List<Book>();
        }
    }
}
