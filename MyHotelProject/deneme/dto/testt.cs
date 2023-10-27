using MongoDB.Bson.Serialization.Attributes;

namespace deneme.dto
{
    [BsonIgnoreExtraElements]

    public class testt
    {

      
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
