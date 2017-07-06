using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Commands.Books;
using eBookRental.Infrastructure.Services;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Handlers.Books
{
    public class CreateBookHandler : ICommandHandler<CreateBook>
    {
        private readonly IBookService _bookService;

        public CreateBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task HandleAsync(CreateBook command)
        {
            await _bookService.CreateAsync(command.Title, command.Description, 
                command.Image, command.Writer, command.Publisher, command.NumberOfSets);
        }
    }
}
