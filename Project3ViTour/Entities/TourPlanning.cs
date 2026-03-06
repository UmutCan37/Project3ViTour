using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Project3ViTour.Entities
{
    public class TourPlanning
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TourPlanningId { get; set; }
        public int DayNumber { get; set; }
        public string DayTitle { get; set; }
        public string Description { get; set; }
        public string Activities { get; set; }
        public string TourId { get; set; }
    }
}
