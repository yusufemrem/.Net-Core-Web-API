using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDtoLayer.BookingDto
{
    public class CreateBookingDto
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public DateTime Ceckin { get; set; }
        public DateTime CheckOut { get; set; }
        public string City { get; set; }
        public string AdultCount { get; set; }
        public string ChildCount { get; set; }
        public string RoomCount { get; set; }
        public string SpecialRequest { get; set; }
    }
}
