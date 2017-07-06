using eBookRental.Infrastructure.DTO;
using System;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Services
{
    public interface IRentalService : IService
    {
        Task Rent(Guid userId, Guid setId);
        Task Return(Guid rentalId);
    }
}
