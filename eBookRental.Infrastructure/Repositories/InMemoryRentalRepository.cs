using eBookRental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using eBookRental.Core.Domain;
using System.Threading.Tasks;
using System.Linq;

namespace eBookRental.Infrastructure.Repositories
{
    public class InMemoryRentalRepository : IRentalRepository
    {
        private static readonly ISet<Rental> _rentals = new HashSet<Rental>();

        public async Task AddAsync(Rental rental)
        {
            _rentals.Add(rental);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Rental>> GetAllAsync()
            => await Task.FromResult(_rentals);

        public async Task<Rental> GetSingleAsync(Guid id)
            => await Task.FromResult(_rentals.SingleOrDefault(x => x.Id == id));
    }
}
