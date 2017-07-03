using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Commands.Books;
using eBookRental.Infrastructure.Services;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Handlers.Books
{
    public class DeleteBookHandler : ICommandHandler<DeleteBook>
    {
        private readonly IBookService _bookService;

        public DeleteBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task HandleAsync(DeleteBook command)
        {
            await _bookService.RemoveAsync(command.BookId);
        }
    }
}
