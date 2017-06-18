using eBookRental.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Core.Repositories
{
    public interface IGenreRepository : IRepository
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<IEnumerable<Genre>> FindBy(Func<Genre, bool> predicate);

        Task<Genre> GetSingleAsync(Guid id);
        Task<Genre> GetSingleAsync(string name);

        Task AddAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task RemoveAsync(Guid id);
    }
}
