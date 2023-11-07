using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
