using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.Controllers
{
    public class MenuItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
