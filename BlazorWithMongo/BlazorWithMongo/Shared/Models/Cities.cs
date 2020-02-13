using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorWithMongo.Shared.Models
{
    public class Cities
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CityName { get; set; }
    }
}
