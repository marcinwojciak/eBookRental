using eBookRental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using eBookRental.Core.Domain;
using System.Threading.Tasks;
using System.Linq;

namespace eBookRental.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>
        {
            new User("tomek@domain.com", "Tomek", "Tomasz Działowy", "sekrett", "salt", "role"),
            new User("ania@domain.com", "Ania", "Anna Działowa",  "sekreta", "salt", "role"),
            new User("michal@domain.com", "Michał", "Michał Kowalski", "sekretm", "salt", "role"),
            new User("ola@domain.com", "Ola", "Aleksandra Kowalska", "sekreto", "salt", "role")
        };

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task<User> GetSingleAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetSingleAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetSingleAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
