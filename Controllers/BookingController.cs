using Microsoft.AspNetCore.Mvc;

namespace HeroApp.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewBookingDate()
        {
            return View();
        }
    }
}
