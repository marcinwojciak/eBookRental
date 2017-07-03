using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBookRental.Core.Domain;
using eBookRental.Infrastructure.DTO;
using eBookRental.Core.Repositories;
using AutoMapper;

namespace eBookRental.Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> GetAllAsync()
        {
            var genres = await _genreRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDto>>(genres);
        }

        public async Task<GenreDto> GetSingleAsync(Guid id)
        {
            var genre = await _genreRepository.GetSingleAsync(id);

            return _mapper.Map<Genre, GenreDto>(genre);
        }

        public async Task<GenreDto> GetSingleAsync(GenreType name)
        {
            var genre = await _genreRepository.GetSingleAsync(name);

            return _mapper.Map<Genre, GenreDto>(genre);
        }
    }
}
