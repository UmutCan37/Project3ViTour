using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Dtos.BookingDtos;
using Project3ViTour.Dtos.ReviewDtos;
using Project3ViTour.Dtos.TourDtos;
using Project3ViTour.Services.BookingService;
using Project3ViTour.Services.ReviewService;
using Project3ViTour.Services.TourService;

namespace Project3ViTour.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IReviewService _reviewService;
        private readonly IBookingService _bookingService;

        public TourController(ITourService tourService, IReviewService reviewService, IBookingService bookingService)
        {
            _tourService = tourService;
            _reviewService = reviewService;
            _bookingService = bookingService;
        }
        public IActionResult CreateTour()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTour(CreateTourDto createDtoTour)
        {
            await _tourService.CreateTourAsync(createDtoTour);
            return RedirectToAction("TourList");
        }

        public IActionResult TourList()
        {
            return View();
        }

        public IActionResult TourDetay(string id)
        {
            ViewBag.TourId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDto createReviewDto)
        {
            createReviewDto.ReviewDate = DateTime.Now;
            createReviewDto.Status = false;
            await _reviewService.CreateReviewAsync(createReviewDto);
            return RedirectToAction("TourDetay", new { id = createReviewDto.TourId });
        }
        public async Task<IActionResult> Booking()
        {
            var tours = await _tourService.GetAllToursAsync();
            return View(tours);
        }

        [HttpPost]
        public async Task<IActionResult> Booking(CreateBookingDto createBookingDto)
        {
            // Turun kapasitesini al
            var tour = await _tourService.GetTourByIdAsync(createBookingDto.TourId);

            // Mevcut toplam konuğu al
            var currentGuests = await _bookingService.GetTotalGuestCountByTourIdAsync(createBookingDto.TourId);

            // Kapasite kontrolü
            if (currentGuests + createBookingDto.GuestCount > tour.Capacity)
            {
                TempData["Error"] = $"Üzgünüz, bu tur için yeterli kontenjan bulunmamaktadır. Kalan kontenjan: {tour.Capacity - currentGuests}";
                return Redirect("/Tour/Booking");
            }

            createBookingDto.IsStatus = true;
            createBookingDto.BookingDate = DateTime.Now;
            await _bookingService.CreateBookingAsync(createBookingDto);
            return Redirect($"/Tour/TourDetay/{createBookingDto.TourId}");
        }
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
    }
}
