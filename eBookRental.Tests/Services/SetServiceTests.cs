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
        [Fact]
        public async Task get_single_async_should_invoke_set_repository_get_single_async_by_id_when_set_exists()
        {
            var setRepositoryMock = new Mock<ISetRepository>();
            var mapperMock = new Mock<IMapper>();

            var setService = new SetService(setRepositoryMock.Object, mapperMock.Object);

            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka", 20);
            var set = new Set(book, true);

            await setService.GetSingleAsync(set.Id);

            setRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<Guid>()))
                              .ReturnsAsync(set);

            setRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_set_repository_get_single_async_by_id_when_set_does_not_exist()
        {
            var setRepositoryMock = new Mock<ISetRepository>();
            var mapperMock = new Mock<IMapper>();

            var setService = new SetService(setRepositoryMock.Object, mapperMock.Object);
            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka", 20);
            var set = new Set(book, true);

            await setService.GetSingleAsync(set.Id);

            setRepositoryMock.Setup(x => x.GetSingleAsync(set.Id))
                              .ReturnsAsync(() => null);

            setRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
