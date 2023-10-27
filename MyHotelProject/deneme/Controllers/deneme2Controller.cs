using deneme.dto;
using deneme.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace deneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class deneme2Controller : ControllerBase
    {
        private readonly IMongoCollection<Test> _testCollection;

        public deneme2Controller()
        {
            var connectionString = "mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb"; // MongoDB sunucu adresi ve port numarası
            var client = new MongoClient(connectionString);
            var databaseName = "MyFirstDatabase"; // MongoDB veritabanı adı
            var database = client.GetDatabase(databaseName);
            _testCollection = database.GetCollection<Test>("Test");
   }
        [HttpPost("Index")]
        public IActionResult Index(testt testt)
        {
            var test = new Test()
            {
               
                Name = testt.Name
            };

            _testCollection.InsertOne(test);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            // Tüm verileri koleksiyondan çekmek için bir sorgu oluşturun
            var filter = Builders<Test>.Filter.Empty;
            var result = _testCollection.Find(filter).ToList(); // Verileri çekin ve bir liste olarak alın

            return Ok(result);
        }
    }
}

