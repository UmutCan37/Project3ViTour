namespace Project3ViTour.Entities
{
    public class Tour
    {
        public string TourId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public string Badge { get; set; }
        public int DayCount { get; set; }
        public int CapCity { get; set; }
        public decimal Price { get; set; }
        public bool IsStatus { get; set; }
    }
}
