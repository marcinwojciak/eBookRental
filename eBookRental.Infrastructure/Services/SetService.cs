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
    public class SetService : ISetService
    {
        private readonly ISetRepository _setRepository;
        private readonly IMapper _mapper;
        private object object1;
        private object object2;

        public SetService(ISetRepository setRepository, IMapper mapper)
        {
            _setRepository = setRepository;
            _mapper = mapper;
        }

        public async Task<SetDto> GetSingleAsync(Guid id)
        {
            var set = await _setRepository.GetSingleAsync(id);

            return _mapper.Map<Set, SetDto>(set);
        }

        public async Task<List<SetDto>> GetAvailableAsync()
        {
            List<Set> sets = new List<Set>();

            var allSets = await _setRepository.GetAllAsync();

            foreach(var set in allSets)
            {
                if (set.IsAvailable == true)
                    sets.Add(set);
            }

            return _mapper.Map<List<Set>, List<SetDto>>(sets);
        }
    }
}
