using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Services.TourService;
using Project3ViTour.Services.LocationService;

namespace Project3ViTour.ViewComponents.TourDetailsViewComponents
{
    public class _TourDetailsLocationComponentPartial : ViewComponent
    {
        private readonly ITourService _tourService;
        private readonly ILocationService _locationService;

        public _TourDetailsLocationComponentPartial(ITourService tourService, ILocationService locationService)
        {
            _tourService = tourService;
            _locationService = locationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tourId = ViewBag.TourId as string;
            var tour = await _tourService.GetTourByIdAsync(tourId);
            var location = await _locationService.GetLocationByIdAsync(tour.LocationId);
            return View(location);
        }
    }
}