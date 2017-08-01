using eBookRental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using eBookRental.Core.Domain;
using System.Threading.Tasks;
using eBookRental.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace eBookRental.Infrastructure.Repositories.EntityRepositories
{
    public class UserRepository : IUserRepository, ISqlRepository
    {
        private readonly eBookRentalContext _context;

        public UserRepository(eBookRentalContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _context.Users.ToListAsync();

        public async Task<User> GetSingleAsync(Guid id)
            => await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetSingleAsync(string email)
            => await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetSingleAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
