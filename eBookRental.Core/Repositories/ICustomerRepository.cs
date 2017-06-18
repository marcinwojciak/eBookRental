using eBookRental.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Core.Repositories
{
    public interface ICustomerRepository : IRepository
    {
        Task<Customer> GetSingleAsync(Guid id);
        Task<Customer> GetSingleAsync(string email);

        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task RemoveAsync(Guid id);
    }
}
