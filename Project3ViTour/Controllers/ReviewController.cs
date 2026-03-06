using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Dtos.ReviewDtos;
using Project3ViTour.Services.ReviewService;
using Project3ViTour.Services.TourService;

namespace Project3ViTour.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ITourService _tourService;

        public ReviewController(IReviewService reviewService, ITourService tourService)
        {
            _reviewService = reviewService;
            _tourService = tourService;
        }
        public async Task<IActionResult> ReviewList()
        {
            var values = await _reviewService.GetAllReviewsAsync();
            var tours = await _tourService.GetAllToursAsync();
            ViewBag.Tours = tours.ToDictionary(t => t.TourId.ToString(), t => t.Title);
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateReview()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDto createReviewDto)
        {
            createReviewDto.Status = false;
            await _reviewService.CreateReviewAsync(createReviewDto);
            return RedirectToAction("ReviewList");
        }
        public async Task<IActionResult> GetReviewByTourId(string id)
        {
            var values = await _reviewService.GetAllReviewsByTourIdAsync(id);
            return View(values);
        }
        public async Task<IActionResult> DeleteReview(string id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return RedirectToAction("ReviewList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateReview(string id)
        {
            var value = await _reviewService.GetReviewByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateReview(UpdateReviewDto updateReviewDto)
        {
            await _reviewService.UpdateReviewAsync(updateReviewDto);
            return RedirectToAction("ReviewList");
        }
    }
}
