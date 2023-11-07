using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
