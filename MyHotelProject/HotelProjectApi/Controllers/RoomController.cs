using FluentValidation.Results;
using MHBusinessLayer.Abstract;
using MHBusinessLayer.ValidationRules;
using MHDtoLayer.RoomDto;
using MHEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet("{id}")]
        public IActionResult getLByRoom(int id)
        {
            var values = _roomService.TGetByID(id);
            return Ok(values);
        }

        [HttpPost("AddRoom")]

        public IActionResult AddRoom(CreateRoomDto createRoomDto)
        {

            CreateRoomValidation csv = new CreateRoomValidation();
            ValidationResult result = csv.Validate(createRoomDto);
            if (result.IsValid)
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
             else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return Ok();
        }


    }
}

