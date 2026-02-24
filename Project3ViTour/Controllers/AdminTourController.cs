using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Dtos.TourDtos;
using Project3ViTour.Services.TourService;

namespace Project3ViTour.Controllers
{
    public class AdminTourController : Controller
    {
        private readonly ITourService _tourService;

        public AdminTourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        public async Task<IActionResult> TourList()
        {
            var values = await _tourService.GetAllToursAsync();
            return View(values);
        }
        [HttpGet]
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
        
    }
}
