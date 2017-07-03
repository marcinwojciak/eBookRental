using AutoMapper;
using eBookRental.Core.Domain;
using eBookRental.Core.Repositories;
using eBookRental.Infrastructure.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace eBookRental.Tests.Services
{
    public class GenreServiceTests
    {
        [Fact]
        public async Task get_single_async_should_invoke_genre_repository_get_single_async_by_genre_type_when_genre_exists()
        {
            var genreRepositoryMock = new Mock<IGenreRepository>();
            var mapperMock = new Mock<IMapper>();

            var genreService = new GenreService(genreRepositoryMock.Object, mapperMock.Object);

            var genre = new Genre(GenreType.Fantasy);

            await genreService.GetSingleAsync(GenreType.Fantasy);

            genreRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<GenreType>()))
                               .ReturnsAsync(genre);

            genreRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<GenreType>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_invoke_genre_repository_get_single_async_by_id_when_genre_exists()
        {
            var genreRepositoryMock = new Mock<IGenreRepository>();
            var mapperMock = new Mock<IMapper>();

            var genreService = new GenreService(genreRepositoryMock.Object, mapperMock.Object);

            var genre = new Genre(GenreType.Fantasy);

            await genreService.GetSingleAsync(genre.Id);

            genreRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<Guid>()))
                             .ReturnsAsync(genre);

            genreRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_book_repository_get_single_async_by_genre_type_when_genre_does_not_exist()
        {
            var genreRepositoryMock = new Mock<IGenreRepository>();
            var mapperMock = new Mock<IMapper>();

            var genreService = new GenreService(genreRepositoryMock.Object, mapperMock.Object);

            await genreService.GetSingleAsync(GenreType.Fantasy);

            genreRepositoryMock.Setup(x => x.GetSingleAsync(GenreType.Fantasy))
                              .ReturnsAsync(() => null);

            genreRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<GenreType>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_genre_repository_get_single_async_by_id_when_genre_does_not_exist()
        {
            var genreRepositoryMock = new Mock<IGenreRepository>();
            var mapperMock = new Mock<IMapper>();

            var genreService = new GenreService(genreRepositoryMock.Object, mapperMock.Object);
            var genreId = Guid.NewGuid();

            await genreService.GetSingleAsync(genreId);

            genreRepositoryMock.Setup(x => x.GetSingleAsync(genreId))
                              .ReturnsAsync(() => null);

            genreRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
