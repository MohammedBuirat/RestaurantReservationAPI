using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
