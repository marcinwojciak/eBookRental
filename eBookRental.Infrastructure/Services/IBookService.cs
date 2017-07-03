using eBookRental.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Services
{
    public interface IBookService : IService
    {
        Task<BookDto> GetSingleAsync(Guid id);
        Task<BookDto> GetSingleAsync(string title);
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<IEnumerable<BookDto>> GetByDateAsync();
        Task<IEnumerable<BookDto>> GetByWriterAsync(string writer);

        Task CreateAsync(string title, string description, string image, string writer, string publisher);
        Task UpdateAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}
