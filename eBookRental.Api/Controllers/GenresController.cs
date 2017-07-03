using eBookRental.Core.Domain;
using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookRental.Api.Controllers
{
    public class GenresController : ApiController
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _genreService = genreService;                  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var genre = await _genreService.GetSingleAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }
        
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(GenreType name)
        {
            var genre = await _genreService.GetSingleAsync(name);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var genre = await _genreService.GetAllAsync();

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }
    }
}
