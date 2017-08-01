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
    public class InMemoryBookRepository : IBookRepository
    {
        private static readonly ISet<Book> _books = new HashSet<Book>();

        public async Task AddAsync(Book book)
        {
            _books.Add(book);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Book>> FindBy(Func<Book, bool> predicate)
            => await Task.FromResult(_books.Where(predicate));

        public async Task<IEnumerable<Book>> GetAllAsync()
            => await Task.FromResult(_books);

        public async Task<Book> GetSingleAsync(Guid id)
            => await Task.FromResult(_books.SingleOrDefault(x => x.Id == id));

        public async Task<Book> GetSingleAsync(string title)
            => await Task.FromResult(_books.SingleOrDefault(x => x.Title == title.ToLowerInvariant()));

        public async Task<IEnumerable<Book>> OrderByDescendingAsync(Func<Book, bool> predicate)
            => await Task.FromResult(_books.OrderByDescending(predicate));

        public async Task RemoveAsync(Guid id)
        {
            var book = await GetSingleAsync(id);
            _books.Remove(book);
            await Task.CompletedTask;
        }

        public Task UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
