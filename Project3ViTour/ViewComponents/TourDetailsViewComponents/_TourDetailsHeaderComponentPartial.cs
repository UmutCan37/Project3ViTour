using Microsoft.AspNetCore.Mvc;

namespace Project3ViTour.ViewComponents.TourDetailsViewComponents
{
    public class _TourDetailsHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
