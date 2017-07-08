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
    public class SetServiceTests
    {
        private readonly Mock<ISetRepository> _setRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public SetServiceTests()
        {
            _setRepositoryMock = new Mock<ISetRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task get_single_async_should_invoke_set_repository_get_single_async_by_id_when_set_exists()
        {
            var setService = new SetService(_setRepositoryMock.Object, _mapperMock.Object);

            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka", 20);
            var set = new Set(book, true);

            await setService.GetSingleAsync(set.Id);

            _setRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<Guid>()))
                              .ReturnsAsync(set);

            _setRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_set_repository_get_single_async_by_id_when_set_does_not_exist()
        {
            var setService = new SetService(_setRepositoryMock.Object, _mapperMock.Object);
            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka", 20);
            var set = new Set(book, true);

            await setService.GetSingleAsync(set.Id);

            _setRepositoryMock.Setup(x => x.GetSingleAsync(set.Id))
                              .ReturnsAsync(() => null);

            _setRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
