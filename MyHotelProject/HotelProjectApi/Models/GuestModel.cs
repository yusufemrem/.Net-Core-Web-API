using MongoDB.Bson.Serialization.Attributes;

namespace HotelProjectApi.Models
{
    [BsonIgnoreExtraElements]
    public class GuestModel
    {

        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Surname")]

        public string Surname { get; set; }
        [BsonElement("City")]

        public string City { get; set; }

    }
}
