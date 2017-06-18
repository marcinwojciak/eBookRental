using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Core.Domain
{
    public class Book
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected  set; }
        public string Image { get; protected set; }
        public string Writer { get; protected set; }
        public string Publisher { get; protected set; }
        public byte Rating { get; protected set; }

        public int GenreId { get; protected set; }
        public virtual Genre Genre { get; protected set; }
        public DateTime ReleaseDate { get; protected set; }

        public IEnumerable<Set> Sets { get; protected set; }

        protected Book()
        {

        }

        public Book(string title, string writer, string publisher)
        {
            Id = Guid.NewGuid();
            Title = title.ToLowerInvariant();
            Writer = writer;
            Publisher = publisher;

            Sets = new List<Set>();
        }
    }
}
