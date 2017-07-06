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
        public byte NumberOfSets { get; protected set; }

        public Guid GenreId { get; protected set; }
        public Genre Genre { get; protected set; }
        public DateTime ReleaseDate { get; protected set; }

        public ICollection<Set> Sets { get; set; }
    
        protected Book()
        {

        }

        public Book(string title, string description, 
            string image, string writer, string publisher, byte numberOfSets)
        {
            Id = Guid.NewGuid();
            Title = title.ToLowerInvariant();
            Description = description;
            Image = image;
            Writer = writer;
            Publisher = publisher;
            NumberOfSets = numberOfSets;

            ReleaseDate = DateTime.UtcNow;
            Sets = new List<Set>();
        }
    }
}
