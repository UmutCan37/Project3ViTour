using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Services.TourService;
using Project3ViTour.Services.GalleryImageService;
using Project3ViTour.Dtos.TourDtos;
using Project3ViTour.Dtos.GalleryImageDtos;

namespace Project3ViTour.ViewComponents.TourDetailsViewComponents
{
    public class _TourDetailsInformationComponentPartial : ViewComponent
    {
        private readonly ITourService _tourService;
        private readonly IGalleryImageService _galleryImageService;

        public _TourDetailsInformationComponentPartial(ITourService tourService, IGalleryImageService galleryImageService)
        {
            _tourService = tourService;
            _galleryImageService = galleryImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tourId = ViewBag.TourId as string;
            var tour = await _tourService.GetTourByIdAsync(tourId);
            var images = await _galleryImageService.GetAllGalleryImageAsync();
            var tourImages = images.Where(x => x.TourId == tourId).Take(3).ToList();
            ViewBag.GalleryImages = tourImages;
            return View(tour);
        }
    }
}