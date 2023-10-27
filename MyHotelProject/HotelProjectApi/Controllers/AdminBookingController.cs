using MHBusinessLayer.Abstract;
using MHDtoLayer.BookingDto;
using MHEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public AdminBookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("BookingList")]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }
        [HttpPost("AdminAddBooking")]
        public IActionResult AdminAddBooking(CreateBookingDto createBookingDto)
        {
            {
                Booking booking = new Booking
                {
                    BookingID = createBookingDto.BookingID,
                    Name = createBookingDto.Name,
                    Ceckin = createBookingDto.Ceckin,
                    CheckOut = createBookingDto.CheckOut,
                    City = createBookingDto.City,
                    AdultCount = createBookingDto.AdultCount,
                    ChildCount = createBookingDto.ChildCount,
                    RoomCount = createBookingDto.RoomCount,
                    SpecialRequest = createBookingDto.SpecialRequest,
                };
                _bookingService.TInsert(booking);
                return Ok();
            }

        }
    }
}
