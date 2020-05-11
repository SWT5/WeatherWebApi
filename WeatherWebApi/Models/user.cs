using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebApi.Models
{
    public class user
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHashed { get; set; }
    }
}
