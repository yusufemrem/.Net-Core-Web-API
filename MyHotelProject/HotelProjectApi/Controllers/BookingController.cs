using MHBusinessLayer.Abstract;
using MHDtoLayer.BookingDto;
using MHEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("AddBooking")]
        public IActionResult AddBooking(CreateBookingDto createBookingDto)
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


        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            _bookingService.TDelete(values);
            return Ok();
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {

            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            return Ok();
        }


    }
}
