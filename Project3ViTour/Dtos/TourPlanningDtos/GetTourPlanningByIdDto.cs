namespace Project3ViTour.Dtos.TourPlanningDtos
{
    public class GetTourPlanningByIdDto
    {
        public string TourPlanningId { get; set; }
        public int DayNumber { get; set; }
        public string DayTitle { get; set; }
        public string Description { get; set; }
        public string Activities { get; set; }
        public string TourId { get; set; }
    }
}
