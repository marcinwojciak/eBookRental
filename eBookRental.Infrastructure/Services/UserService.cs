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
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
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

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetSingleAsync(email);

            if(user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);

            if (user.Password == hash)
            {
                return;
            }

            throw new Exception("Invalid credentials");
        }

        public async Task RegisterAsync(Guid id, string email, string username, 
            string fullName, string password, string role, string identityCard, string mobile)
        {
            var user = await _userRepository.GetSingleAsync(email);

            if(user != null)
            {
                throw new Exception($"User with email: {email} already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(id, email, username, fullName, hash, salt, role, identityCard, mobile);

            await _userRepository.AddAsync(user);
        }
    }
}
