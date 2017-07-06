using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.Commands.Books
{
    public class UpdateBook : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public byte NumberOfSets { get; set; }
    }
}
