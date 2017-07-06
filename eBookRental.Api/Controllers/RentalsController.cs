using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookRental.Api.Controllers
{
    public class RentalsController : ApiController
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _rentalService = rentalService;
        }

        //POST
        [Authorize("user")]
        [HttpPost("rent/{userId}/{setId}")]
        public async Task<IActionResult> Rent(Guid userId, Guid setId)
        {
            await _rentalService.Rent(userId, setId);

            return Created("user", null);
        }

        [Authorize("user")]
        [HttpPost("return/{rentalId}")]
        public async Task<IActionResult> Return(Guid rentalId)
        {
            await _rentalService.Return(rentalId);

            return Created("books", null);
        }
    }
}
