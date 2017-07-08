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
        private readonly Mock<IRentalRepository> _rentalRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Mock<ISetRepository> _setRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public RentalSeviceTests()
        {
            _rentalRepositoryMock = new Mock<IRentalRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _bookRepositoryMock = new Mock<IBookRepository>();
            _setRepositoryMock = new Mock<ISetRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task rent_async_should_invoke_add_async_on_repository()
        {
            var rentalService = new RentalService(_rentalRepositoryMock.Object, _userRepositoryMock.Object, 
                _bookRepositoryMock.Object, _mapperMock.Object, _setRepositoryMock.Object);

            var user = new User(Guid.NewGuid(), "tomek@domain.com", "Tomek", "Tomasz Działowy", "sekrett", "salt", "role", "1234567890987654", "123456789");
            var book = new Book("Lśnienie", "opis", "image.png", "Stephen King", "Prószyński i S-ka", 20);
            var set = new Set(book, true);

            await rentalService.Rent(user.Id, set.Id);

            _rentalRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Rental>()), Times.Once);
        }
    }
}
