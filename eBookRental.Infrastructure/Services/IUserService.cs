using eBookRental.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetSingleAsync(Guid id);
        Task<UserDto> GetSingleAsync(string email);
        Task RegisterAsync(string email, string username, string fullName, string password, string role);
    }
}
