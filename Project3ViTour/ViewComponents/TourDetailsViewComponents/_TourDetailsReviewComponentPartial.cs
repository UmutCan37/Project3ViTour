using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Services.ReviewService;

namespace Project3ViTour.ViewComponents.TourDetailsViewComponents
{
    public class _TourDetailsReviewComponentPartial : ViewComponent
    {
        private readonly IReviewService _reviewService;

        public _TourDetailsReviewComponentPartial(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tourId = ViewBag.TourId as string;
            var reviews = await _reviewService.GetAllReviewsByTourIdAsync(tourId);
            return View(reviews);
        }
    }
}