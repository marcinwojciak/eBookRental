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
    public class BookRepository : IBookRepository, ISqlRepository
    {
        private readonly eBookRentalContext _context;

        public BookRepository(eBookRentalContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> FindBy(Func<Book, bool> predicate)
            => await Task.FromResult(_context.Books.Where(predicate));
        
        public async Task<IEnumerable<Book>> GetAllAsync()
            => await _context.Books.ToListAsync();

        public async Task<Book> GetSingleAsync(Guid id)
            => await _context.Books.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Book> GetSingleAsync(string title)
            => await _context.Books.SingleOrDefaultAsync(x => x.Title == title);

        public async Task<IEnumerable<Book>> OrderByDescendingAsync(Func<Book, bool> predicate)
            => await Task.FromResult(_context.Books.OrderByDescending(predicate));

        public async Task RemoveAsync(Guid id)
        {
            var book = await GetSingleAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
