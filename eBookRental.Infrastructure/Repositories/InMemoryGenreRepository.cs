using eBookRental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using eBookRental.Core.Domain;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace eBookRental.Infrastructure.Repositories
{
    public class InMemoryGenreRepository : IGenreRepository
    {
        private static readonly ISet<Genre> _genres = new HashSet<Genre>();

        public async Task AddAsync(Genre genre)
        {
            _genres.Add(genre);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Genre>> FindBy(Func<Genre, bool> predicate)
            => await Task.FromResult(_genres.Where(predicate));

        public async Task<IEnumerable<Genre>> GetAllAsync()
            => await Task.FromResult(_genres);

        public async Task<Genre> GetSingleAsync(Guid id)
            => await Task.FromResult(_genres.SingleOrDefault(x => x.Id == id));

        public async Task<Genre> GetSingleAsync(string name)
            => await Task.FromResult(_genres.SingleOrDefault(x => x.Name == name.ToLowerInvariant()));

        public async Task RemoveAsync(Guid id)
        {
            var genre = await GetSingleAsync(id);
            _genres.Remove(genre);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Genre genre)
        {
            await Task.CompletedTask;
        }
    }
}
