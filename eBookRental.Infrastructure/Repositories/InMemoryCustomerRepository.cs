using eBookRental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using eBookRental.Core.Domain;
using System.Threading.Tasks;
using System.Linq;

namespace eBookRental.Infrastructure.Repositories
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private static readonly ISet<Customer> _customers = new HashSet<Customer>();

        public async Task AddAsync(Customer customer)
        {
            _customers.Add(customer);
            await Task.CompletedTask;
        }

        public async Task<Customer> GetSingleAsync(Guid id)
            => await Task.FromResult(_customers.SingleOrDefault(x => x.Id == id));

        public async Task<Customer> GetSingleAsync(string email)
            => await Task.FromResult(_customers.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task RemoveAsync(Guid id)
        {
            var customer = await GetSingleAsync(id);
            _customers.Remove(customer);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Customer customer)
        {
            await Task.CompletedTask;
        }
    }
}
