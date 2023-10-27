using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDtoLayer.GuestDto
{
    [BsonIgnoreExtraElements]

    public class GusetDto
    {

        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Surname")]

        public string Surname { get; set; }
        [BsonElement("City")]

        public string City { get; set; }

    }
}
