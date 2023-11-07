using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
