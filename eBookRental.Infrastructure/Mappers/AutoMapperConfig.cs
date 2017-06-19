using AutoMapper;
using eBookRental.Core.Domain;
using eBookRental.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            })
            .CreateMapper();
    }
}
