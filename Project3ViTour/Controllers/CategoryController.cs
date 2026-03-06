using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Dtos.CategoryDtos;
using Project3ViTour.Services.CategoryService;

namespace Project3ViTour.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GetAllCategoriesAsync();
            return View(values);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.CategoryStatus = true;
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("CategoryList");
        }
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var value = await _categoryService.GetCategoryByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("CategoryList");
        }
    }
}
