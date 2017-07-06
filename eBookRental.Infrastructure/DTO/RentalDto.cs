using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.DTO
{
    public class RentalDto
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
