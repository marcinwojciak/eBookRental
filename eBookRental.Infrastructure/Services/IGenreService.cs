using eBookRental.Core.Domain;
using eBookRental.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Services
{
    public interface IGenreService : IService
    {
        Task<GenreDto> GetSingleAsync(Guid id);
        Task<GenreDto> GetSingleAsync(GenreType name);
        Task<IEnumerable<GenreDto>> GetAllAsync();
    }
}
