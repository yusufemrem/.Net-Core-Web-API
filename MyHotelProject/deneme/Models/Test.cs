using MongoDB.Bson.Serialization.Attributes;

namespace deneme.Models
{
    [BsonIgnoreExtraElements]
    public class Test
  
    {
     
        [BsonElement("name")]
        public string Name { get; set; }
    }

}
