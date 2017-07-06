using eBookRental.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Core.Repositories
{
    public interface IRentalRepository : IRepository
    {
        Task AddAsync(Rental rental);
        Task<Rental> GetSingleAsync(Guid id);
        Task<IEnumerable<Rental>> GetAllAsync();
    }
}
