using eBookRental.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eBookRental.Infrastructure.Services
{
    public interface IJwtService
    {
        JwtDto CreateToken(string email, string role);
    }
}
