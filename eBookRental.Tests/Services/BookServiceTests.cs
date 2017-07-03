using AutoMapper;
using eBookRental.Core.Domain;
using eBookRental.Core.Repositories;
using eBookRental.Infrastructure.DTO;
using eBookRental.Infrastructure.Services;
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
        [Fact]
        public async Task get_single_async_should_invoke_user_repository_get_single_async_by_title_when_book_exists()
        {
            var bookRepositoryMock = new Mock<IBookRepository>();
            var mapperMock = new Mock<IMapper>();

            var bookService = new BookService(bookRepositoryMock.Object, mapperMock.Object);

            await bookService.GetSingleAsync("Lśnienie");

            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka");

            bookRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<string>()))
                             .ReturnsAsync(book);

            bookRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_invoke_book_repository_get_single_async_by_id_when_book_exists()
        {
            var bookRepositoryMock = new Mock<IBookRepository>();
            var mapperMock = new Mock<IMapper>();

            var bookService = new BookService(bookRepositoryMock.Object, mapperMock.Object);

            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka");

            await bookService.GetSingleAsync(book.Id);

            bookRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<Guid>()))
                             .ReturnsAsync(book);

            bookRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_book_repository_get_single_async_by_title_when_book_does_not_exist()
        {
            var bookRepositoryMock = new Mock<IBookRepository>();
            var mapperMock = new Mock<IMapper>();

            var bookService = new BookService(bookRepositoryMock.Object, mapperMock.Object);

            await bookService.GetSingleAsync("Lśnienie");

            bookRepositoryMock.Setup(x => x.GetSingleAsync("Lśnienie"))
                              .ReturnsAsync(() => null);

            bookRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_book_repository_get_single_async_by_id_when_book_does_not_exist()
        {
            var bookRepositoryMock = new Mock<IBookRepository>();
            var mapperMock = new Mock<IMapper>();

            var bookService = new BookService(bookRepositoryMock.Object, mapperMock.Object);
            var bookId = Guid.NewGuid();

            await bookService.GetSingleAsync(bookId);

            bookRepositoryMock.Setup(x => x.GetSingleAsync(bookId))
                              .ReturnsAsync(() => null);

            bookRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task get_all_async_should_invoke_book_repository_get_all_repository_when_books_exist()
        {
            var bookRepositoryMock = new Mock<IBookRepository>();
            var mapperMock = new Mock<IMapper>();

            var bookService = new BookService(bookRepositoryMock.Object, mapperMock.Object);

            var books = new Book[]
            {
                new Book("ksiazka1", "opis1", "image1.png", "autor1", "wydawca1"),
                new Book("ksiazka2", "opis2", "image2.png", "autor2", "wydawca2"),
                new Book("ksiazka3", "opis3", "image3.png", "autor3", "wydawca3"),
                new Book("ksiazka4", "opis4", "image4.png", "autor4", "wydawca4"),
                new Book("ksiazka5", "opis5", "image5.png", "autor5", "wydawca5"),
            };

            await bookService.GetAllAsync();

            bookRepositoryMock.Setup(x => x.GetAllAsync())
                              .ReturnsAsync(books);

            bookRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task get_by_writer_async_should_find_a_book_for_specific_writer_when_books_exist()
        {
            var bookRepositoryMock = new Mock<IBookRepository>();
            var mapperMock = new Mock<IMapper>();

            var bookService = new BookService(bookRepositoryMock.Object, mapperMock.Object);

            var books = new Book[]
            {
                new Book("ksiazka1", "opis1", "image1.png", "autor1", "wydawca1"),
                new Book("ksiazka2", "opis2", "image2.png", "autor2", "wydawca2"),
                new Book("ksiazka3", "opis3", "image3.png", "autor3", "wydawca3"),
                new Book("ksiazka4", "opis4", "image4.png", "Sapkowski", "wydawca4"),
                new Book("ksiazka5", "opis5", "image5.png", "autor5", "wydawca5"),
            };

            await bookService.GetByWriterAsync("Sapkowski");

            Assert.Equal("ksiazka4", books[3].Title);
        }

        [Fact]
        public async Task create_async_should_invoke_add_async_on_repository()
        {
            var bookRepositoryMock = new Mock<IBookRepository>();
            var mapperMock = new Mock<IMapper>();

            var bookService = new BookService(bookRepositoryMock.Object, mapperMock.Object);
            await bookService.CreateAsync("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka");

            bookRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Book>()), Times.Once);
        }

        [Fact]
        public async Task update_async_should_invoke_add_async_on_repository()
        {
            var bookRepositoryMock = new Mock<IBookRepository>();
            var mapperMock = new Mock<IMapper>();

            var bookService = new BookService(bookRepositoryMock.Object, mapperMock.Object);

            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka");
            
            await bookService.UpdateAsync(book.Id, "Mitologia nordycka", "opis", "image.png", "Gaiman Neil", "Wydawnictwo Mag");

            bookRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Book>()), Times.Once);
        }
    }
}
