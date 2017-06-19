using AutoMapper;
using eBookRental.Core.Domain;
using eBookRental.Core.Repositories;
using eBookRental.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper; 
        }

        public async Task<UserDto> GetSingleAsync(Guid id)
        {
            var user = await _userRepository.GetSingleAsync(id);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetSingleAsync(string email)
        {
            var user = await _userRepository.GetSingleAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterAsync(string email, string username, 
            string fullName, string password, string role)
        {
            var user = await _userRepository.GetSingleAsync(email);

            if(user != null)
            {
                throw new Exception($"User with email: {email} already exists.");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, fullName, password, salt, role);

            await _userRepository.AddAsync(user);
        }
    }
}
