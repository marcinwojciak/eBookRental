using eBookRental.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetSingleAsync(Guid id);
        Task<User> GetSingleAsync(string email);
        
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(Guid id);
    }
}
