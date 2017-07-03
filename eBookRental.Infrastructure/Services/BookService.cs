using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using eBookRental.Infrastructure.DTO;
using eBookRental.Core.Repositories;
using AutoMapper;
using eBookRental.Core.Domain;

namespace eBookRental.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(string title, string description, string image, string writer, string publisher)
        {
            var book = new Book(title, description, image, writer, publisher);

            await _bookRepository.AddAsync(book);
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(books);
        }
            

        public async Task<IEnumerable<BookDto>> GetByWriterAsync(string writer)
        {
            var writersBooks = await _bookRepository.FindBy(x => x.Writer == writer);

            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(writersBooks);
        }

        public async Task<IEnumerable<BookDto>> GetByDateAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            books.OrderByDescending(x => x.ReleaseDate);

            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetSingleAsync(Guid id)
        {
            var book = await _bookRepository.GetSingleAsync(id);

            return _mapper.Map<Book, BookDto>(book);
        }

        public async Task<BookDto> GetSingleAsync(string title)
        {
            var book = await _bookRepository.GetSingleAsync(title);

            return _mapper.Map<Book, BookDto>(book);
        }

        public async Task RemoveAsync(Guid id)
            => await _bookRepository.RemoveAsync(id);

        public Task UpdateAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        //public async Task UpdateAsync(Guid id, BookDto bookDto)
        //{
        //    var book = await _bookRepository.GetSingleAsync(id);

        //    if(book == null)
        //    {
        //        throw new Exception($"Book with id:{id} doesnt exist.");
        //    }

        //    _mapper.Map(bookDto, book);

        //    await _bookRepository.AddAsync(book);
        //}
    }
}
