using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Commands.Books;
using eBookRental.Infrastructure.Services;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Handlers.Books
{
    public class UpdateBookHandler : ICommandHandler<UpdateBook>
    {
        private readonly IBookService _bookService;

        public UpdateBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task HandleAsync(UpdateBook command)
        {
            await _bookService.UpdateAsync(command.Id, command.Title, command.Description,
                command.Image, command.Writer, command.Publisher);
        }
    }
}
