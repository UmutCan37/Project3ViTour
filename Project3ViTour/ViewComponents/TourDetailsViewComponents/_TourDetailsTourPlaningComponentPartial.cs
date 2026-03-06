using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Services.TourPlanningService;

namespace Project3ViTour.ViewComponents.TourDetailsViewComponents
{
    public class _TourDetailsTourPlaningComponentPartial : ViewComponent
    {
        private readonly ITourPlanningService _tourPlanningService;

        public _TourDetailsTourPlaningComponentPartial(ITourPlanningService tourPlanningService)
        {
            _tourPlanningService = tourPlanningService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tourId = ViewBag.TourId as string;
            var plannings = await _tourPlanningService.GetAllTourPlanningAsync();
            var tourPlannings = plannings.Where(x => x.TourId == tourId).OrderBy(x => x.DayNumber).ToList();
            return View(tourPlannings);
        }
    }
}