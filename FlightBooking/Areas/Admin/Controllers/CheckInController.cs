using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu area , Admin alanına ait olduğunu belirtir
    public class CheckInController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
