using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;

        public DataInitializer(IUserService userService)
        {
            _userService = userService;
        }

        public async Task SeedDataAsync()
        {
            for(var i = 1; i<=15; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}"; 
                await _userService.RegisterAsync(userId, $"{username}@domain.com", 
                    username, $"{username}-{i}" ,"secret", "user");
            }

            for (var i = 1; i <=5; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                await _userService.RegisterAsync(userId, $"{username}@domain.com",
                    username, $"{username}-{i}", "secret", "admin");
            }
        }
    }
}
