﻿using AutoMapper;
using eBookRental.Core.Domain;
using eBookRental.Core.Repositories;
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
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterAsync("aaa@email.com", "Aneta", "Żaneta", "klep", "kotleta");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_invoke_user_repository_get_single_async_when_user_exists()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            await userService.GetSingleAsync("tomek@domain.com");

            var user = new User("tomek@domain.com", "Tomek", "Tomasz Działowy", "sekrett", "salt", "role");

            userRepositoryMock.Setup(x => x.GetSingleAsync(It.IsAny<string>()))
                              .ReturnsAsync(user);

            userRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task get_single_async_should_not_invoke_user_repository_get_single_async_when_user__does_not_exist()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            await userService.GetSingleAsync("tomek@domain.com");

            userRepositoryMock.Setup(x => x.GetSingleAsync("tomek@domain.com"))
                              .ReturnsAsync(() => null);

            userRepositoryMock.Verify(x => x.GetSingleAsync(It.IsAny<string>()), Times.Once);
        }
    }
}