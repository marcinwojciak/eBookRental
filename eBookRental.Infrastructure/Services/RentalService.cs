using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBookRental.Infrastructure.DTO;
using eBookRental.Core.Repositories;
using AutoMapper;
using eBookRental.Core.Domain;

namespace eBookRental.Infrastructure.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ISetRepository _setRepository;
        private readonly IMapper _mapper;

        public RentalService(IRentalRepository rentalRepository, IUserRepository userRepository, 
            IBookRepository bookRepository, IMapper mapper, ISetRepository setRepository)
        {
            _rentalRepository = rentalRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _setRepository = setRepository;
            _mapper = mapper;
        }

        public async Task Rent(Guid userId, Guid setId)
        {
            var user = await _userRepository.GetSingleAsync(userId);
            var set = await _setRepository.GetSingleAsync(setId);

            if (user == null || set == null)
            {
                throw new Exception("Given user or set is invalid. Cannot finish rent operation.");
            }
            else if (set.IsAvailable)
            {
                var rental = new Rental(RentalStatus.Borrowed, setId, userId, DateTime.UtcNow);
                await _rentalRepository.AddAsync(rental);
                set.IsAvailable = false;
            }
            else
                throw new Exception("Given set is not available.");
        }

        public async Task Return(Guid rentalId)
        {
            var rental = await _rentalRepository.GetSingleAsync(rentalId);

            if (rental == null)
            {
                throw new Exception($"Rental with id: {rentalId} doesnt exist");
            }   
            else
            {
                rental.Status = RentalStatus.Returned;
                rental.Set.IsAvailable = true;
                rental.ReturnedDate = DateTime.UtcNow;
            }
        }
    }
}
