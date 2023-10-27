using MHBusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IRoomService _roomService;
        private readonly IAppUserService _appUserService;
        private readonly IBookingService _bookingService;
        public AdminWidgetsController(IStaffService staffService, IRoomService roomService, IAppUserService appUserService, IBookingService bookingService)
        {
            _staffService = staffService;
            _roomService = roomService;
             _appUserService = appUserService;
            _bookingService = bookingService;
        }

        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        }

        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var value = _roomService.TGetRoomCount();
            return Ok(value);
        }
        [HttpGet("AppUserCount")]
        public IActionResult AppUserCount()
        {
            var value = _appUserService.TAppUserCount();
            return Ok(value);
        }
        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var value = _bookingService.TGetBookingCount();
            return Ok(value);
        }
    }
}
