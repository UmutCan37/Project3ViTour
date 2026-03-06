using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Project3ViTour.Dtos.LocationDtos
{
    public class UpdateLocationDto
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
