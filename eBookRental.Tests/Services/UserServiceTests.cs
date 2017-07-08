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
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IEncrypter> _encrypterMock;
        private readonly Mock<IMapper> _mapperMock;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _encrypterMock = new Mock<IEncrypter>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            _encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("hash");
            _encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("salt");

            var userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object, _encrypterMock.Object);
            await userService.RegisterAsync(Guid.NewGuid(), "aaa@email.com", "Aneta", "Żaneta", "klep", "kotleta", "1234567890987654", "123456789");

            _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_invoke_user_repository_get_single_async_by_email_when_user_exists()
        {
            _encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("hash");
            _encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("salt");

            var userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object, _encrypterMock.Object);

            await userService.GetSingleAsync("tomek@domain.com");

            var user = new User(Guid.NewGuid(), "tomek@domain.com", "Tomek", "Tomasz Działowy", "sekrett", "salt", "role", "1234567890987654", "123456789");

            _userRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<string>()))
                              .ReturnsAsync(user);

            _userRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_invoke_user_repository_get_single_async_by_id_when_user_exists()
        {
            _encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("hash");
            _encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("salt");

            var userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object, _encrypterMock.Object);

            var user = new User(Guid.NewGuid(), "tomek@domain.com", "Tomek", "Tomasz Działowy", "sekrett", "salt", "role", "1234567890987654", "123456789");

            await userService.GetSingleAsync(user.Id);

            _userRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<Guid>()))
                             .ReturnsAsync(user);

            _userRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_user_repository_get_single_async_when_user__does_not_exist()
        {
            var userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object, _encrypterMock.Object);

            await userService.GetSingleAsync("tomek@domain.com");

            _userRepositoryMock.Setup(x => x.GetSingleAsync("tomek@domain.com"))
                              .ReturnsAsync(() => null);

            _userRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
