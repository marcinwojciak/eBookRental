using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookRental.Api.Controllers
{
    public class SetsController : ApiController
    {
        private readonly ISetService _setService;

        public SetsController(ISetService setService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _setService = setService;
        }

        //GET
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var set = await _setService.GetSingleAsync(id);

            if (set == null)
            {
                return NotFound();
            }

            return Ok(set);
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailable()
        {
            var sets = await _setService.GetAvailableAsync();

            if (sets == null)
            {
                return NotFound();
            }

            return Ok(sets);
        }
    }
}
