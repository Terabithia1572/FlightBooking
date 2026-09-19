using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    public class CheckInController : Controller
    {
        [Area("Admin")] // Bu area , Admin alanına ait olduğunu belirtir
        public IActionResult Index()
        {
            return View();
        }
    }
}
