using eBookRental.Core.Repositories;
using eBookRental.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using eBookRental.Core.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eBookRental.Infrastructure.Repositories.EntityRepositories
{
    public class RentalRepository : IRentalRepository, ISqlRepository
    {
        private readonly eBookRentalContext _context;

        public RentalRepository(eBookRentalContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rental rental)
        {
            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rental>> GetAllAsync()
            => await _context.Rentals.ToListAsync();

        public async Task<Rental> GetSingleAsync(Guid id)
            => await _context.Rentals.SingleOrDefaultAsync(x => x.Id == id);
    }
}
