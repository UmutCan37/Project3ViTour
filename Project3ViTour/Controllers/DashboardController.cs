using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Services.BookingService;
using Project3ViTour.Services.CategoryService;
using Project3ViTour.Services.GalleryImageService;
using Project3ViTour.Services.LocationService;
using Project3ViTour.Services.ReviewService;
using Project3ViTour.Services.TourPlanningService;
using Project3ViTour.Services.TourService;

namespace Project3ViTour.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IBookingService _bookingService;
        private readonly IReviewService _reviewService;
        private readonly ILocationService _locationService;
        private readonly ICategoryService _categoryService;
        private readonly IGalleryImageService _galleryImageService;
        private readonly ITourPlanningService _tourPlanningService;

        public DashboardController(
            ITourService tourService,
            IBookingService bookingService,
            IReviewService reviewService,
            ILocationService locationService,
            ICategoryService categoryService,
            IGalleryImageService galleryImageService,
            ITourPlanningService tourPlanningService)
        {
            _tourService = tourService;
            _bookingService = bookingService;
            _reviewService = reviewService;
            _locationService = locationService;
            _categoryService = categoryService;
            _galleryImageService = galleryImageService;
            _tourPlanningService = tourPlanningService;
        }

        public async Task<IActionResult> Index()
        {
            var tours = await _tourService.GetAllToursAsync();
            var bookings = await _bookingService.GetAllBookingAsync();
            var locations = await _locationService.GetAllLocationsAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();
            var gallery = await _galleryImageService.GetAllGalleryImageAsync();
            var plannings = await _tourPlanningService.GetAllTourPlanningAsync();

            var avgRating = await _reviewService.GetAverageRatingAsync();
            var lastReviews = await _reviewService.GetLastReviewsAsync(3);

            var lastBookings = bookings
                .OrderByDescending(x => x.BookingDate)
                .Take(5)
                .ToList();

            var tourDict = tours.ToDictionary(t => t.TourId.ToString(), t => t.Title);

            ViewBag.TourCount = tours.Count;
            ViewBag.BookingCount = bookings.Count;
            ViewBag.AvgRating = avgRating;
            ViewBag.LocationCount = locations.Count;
            ViewBag.CategoryCount = categories.Count;
            ViewBag.GalleryCount = gallery.Count;
            ViewBag.PlanningCount = plannings.Count;

            ViewBag.LastBookings = lastBookings;
            ViewBag.LastReviews = lastReviews;
            ViewBag.TourDict = tourDict;

            return View();
        }
    }
}