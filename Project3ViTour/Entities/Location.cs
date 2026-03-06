using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Project3ViTour.Entities
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string LocationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string MapLocationImageUrl { get; set; }
    }
}
