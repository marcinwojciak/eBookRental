using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.DTO
{
    public class JwtDto
    {
        public string Token { get; set; }
        public long TokenLifeTime { get; set; }
    }
}
