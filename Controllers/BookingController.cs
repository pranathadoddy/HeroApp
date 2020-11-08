using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        public async Task<IActionResult> ViewPrice()
        {
            return View();
        }
    }
}
