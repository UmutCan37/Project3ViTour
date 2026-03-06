using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Dtos.LocationDtos;
using Project3ViTour.Services.LocationService;
using System.Threading.Tasks;

namespace Project3ViTour.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _locationService.GetAllLocationsAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            await _locationService.CreateLocationAsync(createLocationDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteLocation(string id)
        {
            await _locationService.DeleteLocationAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateLocation(string id)
        {
            var value = await _locationService.GetLocationByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            await _locationService.UpdateLocationAsync(updateLocationDto);
            return RedirectToAction("Index");
        }
    }
}
