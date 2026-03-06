using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Project3ViTour.Entities
{
    public class Booking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookingId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int GuestCount { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsStatus { get; set; }
        public string TourId { get; set; }
    }
}
