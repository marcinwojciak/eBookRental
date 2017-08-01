using eBookRental.Core.Repositories;
using eBookRental.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using eBookRental.Core.Domain;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eBookRental.Infrastructure.Repositories.EntityRepositories
{
    public class SetRepository : ISetRepository, ISqlRepository
    {
        private readonly eBookRentalContext _context;

        public SetRepository(eBookRentalContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Set set)
        {
            await _context.Sets.AddAsync(set);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Set>> FindBy(Func<Set, bool> predicate)
            => await Task.FromResult(_context.Sets.Where(predicate));

        public async Task<IEnumerable<Set>> GetAllAsync()
            => await _context.Sets.ToListAsync();

        public async Task<IEnumerable<Set>> GetAsync(Guid bookId)
            => await Task.FromResult(_context.Sets.Where(x => x.BookId == bookId));

        public async Task<Set> GetSingleAsync(Guid id)
            => await _context.Sets.SingleOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(Guid id)
        {
            var set = await GetSingleAsync(id);
            _context.Sets.Remove(set);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Set set)
        {
            _context.Sets.Update(set);
            await _context.SaveChangesAsync();
        }
    }
}
