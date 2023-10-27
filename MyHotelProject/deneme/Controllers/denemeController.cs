using deneme.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace deneme.Controllers
{
    public class denemeController : Controller
    {
        [HttpPost("Index")]
        public IActionResult Index()
        {
            var connectionString = "mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb"; // MongoDB sunucu adresi ve port numarası
            var client = new MongoClient(connectionString);
            var databaseName = "MyFirstDatabase"; // MongoDB veritabanı adı
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<Test>("Test");

            var test = new Test()
            {
                
                Name = "yusuf emremm"
            };
        
            collection.InsertOne(test);
            return View();
        }
    }
}
