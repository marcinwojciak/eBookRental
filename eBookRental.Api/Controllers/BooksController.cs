using eBookRental.Infrastructure.Commands;
using eBookRental.Infrastructure.Commands.Books;
using eBookRental.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookRental.Api.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _bookService = bookService;
        }

        //GET
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var book = await _bookService.GetSingleAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> Get(string title)
        {
            var book = await _bookService.GetSingleAsync(title);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("{writer}")]
        public async Task<IActionResult> GetByWriter(string writer)
        {
            var books = await _bookService.GetByWriterAsync(writer);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookService.GetAllAsync();

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatest()
        {
            var books = await _bookService.GetByDateAsync();

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        //POST
        [Authorize("admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateBook command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            await CommandDispatcher.DispatchAsync(command);

            return Created($"drivers/{command.Title}", null);
        }

        //PUT
        [Authorize("admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateBook command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

        //DELETE
        [Authorize("admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await CommandDispatcher.DispatchAsync(new DeleteBook());

            return NoContent();
        }
    }
}
