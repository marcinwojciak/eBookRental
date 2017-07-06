using AutoMapper;
using eBookRental.Core.Domain;
using eBookRental.Core.Repositories;
using eBookRental.Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace eBookRental.Tests.Services
{
    public class RentalSeviceTests
    {
        [Fact]
        public async Task rent_async_should_invoke_add_async_on_repository()
        {
            var rentalRepositoryMock = new Mock<IRentalRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var bookRepositoryMock = new Mock<IBookRepository>();
            var setRepositoryMock = new Mock<ISetRepository>();
            var mapperMock = new Mock<IMapper>();

            var rentalService = new RentalService(rentalRepositoryMock.Object, userRepositoryMock.Object, 
                bookRepositoryMock.Object, mapperMock.Object, setRepositoryMock.Object);

            var user = new User(Guid.NewGuid(), "tomek@domain.com", "Tomek", "Tomasz Działowy", "sekrett", "salt", "role", "1234567890987654", "123456789");
            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka", 20);
            var set = new Set(book, true);

            await rentalService.Rent(user.Id, set.Id);

            rentalRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Rental>()), Times.Once);
        }
    }
}
