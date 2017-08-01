using eBookRental.Core.Repositories;
using eBookRental.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using eBookRental.Core.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eBookRental.Infrastructure.Repositories.EntityRepositories
{
    public class GenreRepository : IGenreRepository, ISqlRepository
    {
        private readonly eBookRentalContext _context;

        public GenreRepository(eBookRentalContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> FindBy(Func<Genre, bool> predicate)
            => await Task.FromResult(_context.Genres.Where(predicate));

        public async Task<IEnumerable<Genre>> GetAllAsync()
            => await _context.Genres.ToListAsync();

        public async Task<Genre> GetSingleAsync(Guid id)
            => await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Genre> GetSingleAsync(GenreType name)
            => await _context.Genres.SingleOrDefaultAsync(x => x.Name == name);

        public async Task RemoveAsync(Guid id)
        {
            var genre = await GetSingleAsync(id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }
    }
}
