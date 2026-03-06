using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Services.GalleryImageService;

namespace Project3ViTour.ViewComponents.TourDetailsViewComponents
{
    public class _TourDetailsGaleryComponentPartial : ViewComponent
    {
        private readonly IGalleryImageService _galleryImageService;

        public _TourDetailsGaleryComponentPartial(IGalleryImageService galleryImageService)
        {
            _galleryImageService = galleryImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tourId = ViewBag.TourId as string;
            var images = await _galleryImageService.GetAllGalleryImageAsync();
            var tourImages = images.Where(x => x.TourId == tourId).ToList();
            return View(tourImages);
        }
    }
}