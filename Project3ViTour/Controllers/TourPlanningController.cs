using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project3ViTour.Dtos.TourPlanningDtos;
using Project3ViTour.Services.TourPlanningService;
using Project3ViTour.Services.TourService;
using System.Threading.Tasks;

namespace Project3ViTour.Controllers
{
    public class TourPlanningController : Controller
    {
        private readonly ITourPlanningService _tourPlanningService;
        private readonly ITourService _tourService;

        public TourPlanningController(ITourPlanningService tourPlanningService, ITourService tourService)
        {
            _tourPlanningService = tourPlanningService;
            _tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _tourPlanningService.GetAllTourPlanningAsync();
            var tours = await _tourService.GetAllToursAsync();
            ViewBag.Tours = tours.ToDictionary(t => t.TourId.ToString(), t => t.Title);
            return View(value);
        }
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> CreateTourPlanning()
        {
            var tours = await _tourService.GetAllToursAsync();
            ViewBag.Tours = new SelectList(
                tours.Select(t => new { Value = t.TourId.ToString(), Text = t.Title }),
                "Value", "Text"
            );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTourPlanning(CreateTourPlanningDto createTourPlanningDto)
        {
            await _tourPlanningService.CreateTourPlanningAsync(createTourPlanningDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTourPlanning(string id)
        {
            await _tourPlanningService.DeleteTourPlanningAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTourPlanning(string id)
        {
            var tours = await _tourService.GetAllToursAsync();
            ViewBag.Tours = new SelectList(
                tours.Select(t => new { Value = t.TourId.ToString(), Text = t.Title }),
                "Value", "Text"
            );
            var value = await _tourPlanningService.GetTourPlanningByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTourPlanning(UpdateTourPlanningDto updateTourPlanningDto)
        {
            await _tourPlanningService.UpdateTourPlanningAsync(updateTourPlanningDto);
            return RedirectToAction("Index");
        }
    }
}

