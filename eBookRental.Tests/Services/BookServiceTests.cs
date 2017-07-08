using AutoMapper;
using eBookRental.Core.Domain;
using eBookRental.Core.Repositories;
using eBookRental.Infrastructure.DTO;
using eBookRental.Infrastructure.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace eBookRental.Tests.Services
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public BookServiceTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task get_single_async_should_invoke_user_repository_get_single_async_by_title_when_book_exists()
        {
            var bookService = new BookService(_bookRepositoryMock.Object, _mapperMock.Object);

            await bookService.GetSingleAsync("Lśnienie");

            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka", 20);

            _bookRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<string>()))
                             .ReturnsAsync(book);

            _bookRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_invoke_book_repository_get_single_async_by_id_when_book_exists()
        {
            var bookService = new BookService(_bookRepositoryMock.Object, _mapperMock.Object);

            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka", 20);

            await bookService.GetSingleAsync(book.Id);

            _bookRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<Guid>()))
                             .ReturnsAsync(book);

            _bookRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_book_repository_get_single_async_by_title_when_book_does_not_exist()
        {
            var bookService = new BookService(_bookRepositoryMock.Object, _mapperMock.Object);

            await bookService.GetSingleAsync("Lśnienie");

            _bookRepositoryMock.Setup(x => x.GetSingleAsync("Lśnienie"))
                              .ReturnsAsync(() => null);

            _bookRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_book_repository_get_single_async_by_id_when_book_does_not_exist()
        {
            var bookService = new BookService(_bookRepositoryMock.Object, _mapperMock.Object);
            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka", 20);

            await bookService.GetSingleAsync(book.Id);

            _bookRepositoryMock.Setup(x => x.GetSingleAsync(book.Id))
                              .ReturnsAsync(() => null);

            _bookRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task get_all_async_should_invoke_book_repository_get_all_repository_when_books_exist()
        {
            var bookService = new BookService(_bookRepositoryMock.Object, _mapperMock.Object);

            var books = new Book[]
            {
                new Book("ksiazka1", "opis1", "image1.png", "autor1", "wydawca1", 20),
                new Book("ksiazka2", "opis2", "image2.png", "autor2", "wydawca2", 20),
                new Book("ksiazka3", "opis3", "image3.png", "autor3", "wydawca3", 20),
                new Book("ksiazka4", "opis4", "image4.png", "autor4", "wydawca4", 20),
                new Book("ksiazka5", "opis5", "image5.png", "autor5", "wydawca5", 20),
            };

            await bookService.GetAllAsync();

            _bookRepositoryMock.Setup(x => x.GetAllAsync())
                              .ReturnsAsync(books);

            _bookRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task get_by_writer_async_should_find_a_book_for_specific_writer_when_books_exist()
        {
            var bookService = new BookService(_bookRepositoryMock.Object, _mapperMock.Object);

            var books = new Book[]
            {
                new Book("ksiazka1", "opis1", "image1.png", "autor1", "wydawca1", 20),
                new Book("ksiazka2", "opis2", "image2.png", "autor2", "wydawca2", 20),
                new Book("ksiazka3", "opis3", "image3.png", "autor3", "wydawca3", 20),
                new Book("ksiazka4", "opis4", "image4.png", "Sapkowski", "wydawca4", 20),
                new Book("ksiazka5", "opis5", "image5.png", "autor5", "wydawca5", 20),
            };

            await bookService.GetByWriterAsync("Sapkowski");

            books[3].Title.ShouldBeEquivalentTo("ksiazka4");
        }

        [Fact]
        public async Task create_async_should_invoke_add_async_on_repository()
        {
            var bookService = new BookService(_bookRepositoryMock.Object, _mapperMock.Object);
            await bookService.CreateAsync("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka", 20);

            _bookRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Book>()), Times.Once);
        }
    }
}
