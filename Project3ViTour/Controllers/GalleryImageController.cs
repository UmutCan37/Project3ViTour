using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Dtos.GalleryImageDtos;
using Project3ViTour.Services.GalleryImageService;
using Project3ViTour.Services.TourService;
using System.Threading.Tasks;

namespace Project3ViTour.Controllers
{
    public class GalleryImageController : Controller
    {
        private readonly IGalleryImageService _galleryImageService;
        private readonly ITourService _tourService;

        public GalleryImageController(IGalleryImageService galleryImageService, ITourService tourService)
        {
            _galleryImageService = galleryImageService;
            _tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _galleryImageService.GetAllGalleryImageAsync();
            var tours = await _tourService.GetAllToursAsync();
            ViewBag.Tours = tours.ToDictionary(t => t.TourId, t => t.Title);
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateGalleryImage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGalleryImage(CreateGalleryImageDto createGalleryImageDto)
        {
            await _galleryImageService.CreateGalleryImageAsync(createGalleryImageDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteGalleryImage(string id)
        {
            await _galleryImageService.DeleteGalleryImageAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGalleryImage(string id)
        {
            var value = await _galleryImageService.GetGalleryImageByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGalleryImage(UpdateGalleryImageDto updateGalleryImageDto)
        {
            await _galleryImageService.UpdateGalleryImageAsync(updateGalleryImageDto);
            return RedirectToAction("Index");
        }
    }
}