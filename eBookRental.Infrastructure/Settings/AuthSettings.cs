using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.Settings
{
    public class AuthSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int TokenLifeTimeMinutes { get; set; }
    }
}
