using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
