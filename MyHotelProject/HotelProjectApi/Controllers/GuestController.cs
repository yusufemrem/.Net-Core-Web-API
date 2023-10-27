using HotelProjectApi.Models;
using MHBusinessLayer.Abstract;
using MHDtoLayer.GuestDto;
using MHEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IMongoCollection<GuestModel> _guestModelCollection;

        public GuestController()
        {
            var connectionString = "mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb"; // MongoDB sunucu adresi ve port numarası
            var client = new MongoClient(connectionString);
            var databaseName = "MyFirstDatabase"; // MongoDB veritabanı adı
            var database = client.GetDatabase(databaseName);
            _guestModelCollection = database.GetCollection<GuestModel>("Guest");
        }
        [HttpPost("Index")]
        public IActionResult Index(GuestModel guestModel)
        {
            var GusetDto = new GusetDto()
            {

                Name = guestModel.Name,
                Surname = guestModel.Surname,
                City = guestModel.City,
            };

            _guestModelCollection.InsertOne(guestModel);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            // Tüm verileri koleksiyondan çekmek için bir sorgu oluşturun
            var filter = Builders<GuestModel>.Filter.Empty;
            var result = _guestModelCollection.Find(filter).ToList(); // Verileri çekin ve bir liste olarak alın

            return Ok(result);
        }
        //private readonly IGuestService _GuestService;
        //public GuestController(IGuestService GuestService)
        //{
        //    _GuestService = GuestService;
        //}

        //[HttpGet]
        //public IActionResult GuestList()
        //{
        //    var values = _GuestService.TGetList();
        //    return Ok(values);
        //}
        //[HttpPost]
        //public IActionResult AddGuest(Guest guest)
        //{
        //    _GuestService.TInsert(guest);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult DeleteGuest(int id)
        //{
        //    var values = _GuestService.TGetByID(id);
        //    _GuestService.TDelete(values);
        //    return Ok();
        //}
        //[HttpPut("UpdateGuest")]
        //public IActionResult UpdateGuest(Guest guest)
        //{
        //    _GuestService.TUpdate(guest);
        //    return Ok();
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetGuest(int id)
        //{
        //    var values = _GuestService.TGetByID(id);
        //    return Ok(values);
        //}
    }
}
