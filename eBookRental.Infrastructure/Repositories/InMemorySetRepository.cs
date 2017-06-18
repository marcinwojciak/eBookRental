using eBookRental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using eBookRental.Core.Domain;
using System.Threading.Tasks;
using System.Linq;

namespace eBookRental.Infrastructure.Repositories
{
    class InMemorySetRepository : ISetRepository
    {
        private static readonly ISet<Set> _sets = new HashSet<Set>();

        public async Task AddAsync(Set set)
        {
            _sets.Add(set);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Set>> FindBy(Func<Set, bool> predicate)
            => await Task.FromResult(_sets.Where(predicate));

        public async Task<IEnumerable<Set>> GetAllAsync()
            => await Task.FromResult(_sets);

        public async Task<Set> GetSingleAsync(Guid id)
            => await Task.FromResult(_sets.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Set>> GetAsync(Guid bookId)
             => await Task.FromResult(_sets.Where(x => x.BookId == bookId));

        public async Task RemoveAsync(Guid id)
        {
            var set = await GetSingleAsync(id);
            _sets.Remove(set);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Set set)
        {
            await Task.CompletedTask;
        }
    }
}
