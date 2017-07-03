using System;

namespace eBookRental.Infrastructure.Commands.Books
{
    public class DeleteBook : ICommand
    {
        public Guid BookId { get; set; }
    }
}
