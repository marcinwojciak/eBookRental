using eBookRental.Core.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        public DataInitializer(IUserService userService, IBookService bookService)
        {
            _userService = userService;
            _bookService = bookService;
        }

        public async Task SeedDataAsync()
        {
            for (var i = 1; i <= 15; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                await _userService.RegisterAsync(userId, $"{username}@domain.com",
                    username, $"{username}-{i}", "secret", "user", "1234567890987654", "123456789");
            }

            for (var i = 1; i <= 15; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                await _userService.RegisterAsync(userId, $"{username}@domain.com",
                    username, $"{username}-{i}", "secret", "admin", "1234567890987654", "123456789");
            }
        }
    }
}
