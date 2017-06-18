using eBookRental.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Core.Repositories
{
    public interface ISetRepository : IRepository
    {
        Task<IEnumerable<Set>> GetAllAsync();
        Task<IEnumerable<Set>> FindBy(Func<Set, bool> predicate);
        Task<IEnumerable<Set>> GetAsync(Guid bookId);

        Task<Set> GetSingleAsync(Guid id);
        
        Task AddAsync(Set set);
        Task UpdateAsync(Set set);
        Task RemoveAsync(Guid id);
    }
}
