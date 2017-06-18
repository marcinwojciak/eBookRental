using eBookRental.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Core.Repositories
{
    public interface IBookRepository : IRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> FindBy(Func<Book, bool> predicate);

        Task<Book> GetSingleAsync(Guid id);
        Task<Book> GetSingleAsync(string title);

        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task RemoveAsync(Guid id);
    }
}
