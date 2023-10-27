using MHBusinessLayer.Abstract;
using MHDtoLayer.RoomDto;
using MHEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRoomController : ControllerBase
    {

        private IRoomService _roomService;

        public AdminRoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet("getListRoom")]
        public IActionResult getListRoom()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }

        [HttpPost("AdminAddRoom")]

        public IActionResult AdminAddRoom(CreateRoomDto createRoomDto)
        {
            Room room = new Room
            {
                RoomNumber = createRoomDto.RoomNumber,
                Price = createRoomDto.Price,
                Title = createRoomDto.Title,
                BedCount = createRoomDto.BedCount,
                Wifi = createRoomDto.Wifi,

            };
            _roomService.TInsert(room);
            return Ok();
        }
    }
}
