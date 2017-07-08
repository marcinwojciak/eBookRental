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
        private readonly Mock<IGenreRepository> _genreRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public GenreServiceTests()
        {
            _genreRepositoryMock = new Mock<IGenreRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task get_single_async_should_invoke_genre_repository_get_single_async_by_genre_type_when_genre_exists()
        {
            var genreService = new GenreService(_genreRepositoryMock.Object, _mapperMock.Object);

            var genre = new Genre(GenreType.Fantasy);

            await genreService.GetSingleAsync(GenreType.Fantasy);

            _genreRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<GenreType>()))
                               .ReturnsAsync(genre);

            _genreRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<GenreType>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_invoke_genre_repository_get_single_async_by_id_when_genre_exists()
        {
            var genreService = new GenreService(_genreRepositoryMock.Object, _mapperMock.Object);

            var genre = new Genre(GenreType.Fantasy);

            await genreService.GetSingleAsync(genre.Id);

            _genreRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<Guid>()))
                             .ReturnsAsync(genre);

            _genreRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_book_repository_get_single_async_by_genre_type_when_genre_does_not_exist()
        {
            var genreService = new GenreService(_genreRepositoryMock.Object, _mapperMock.Object);

            await genreService.GetSingleAsync(GenreType.Fantasy);

            _genreRepositoryMock.Setup(x => x.GetSingleAsync(GenreType.Fantasy))
                              .ReturnsAsync(() => null);

            _genreRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<GenreType>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_genre_repository_get_single_async_by_id_when_genre_does_not_exist()
        {
            var genreService = new GenreService(_genreRepositoryMock.Object, _mapperMock.Object);
            var genreId = Guid.NewGuid();

            await genreService.GetSingleAsync(genreId);

            _genreRepositoryMock.Setup(x => x.GetSingleAsync(genreId))
                              .ReturnsAsync(() => null);

            _genreRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
