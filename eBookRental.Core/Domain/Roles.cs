using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Core.Domain
{
    public static class Roles
    {
        public static Guid UserId { get; set; }

        public static string User => "user";
        public static string Admin => "admin";
    }
}
