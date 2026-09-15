using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu controller'ın Admin Area alanına ait olduğunu belirtir
    public class BookingController : Controller
    {
        public IActionResult CreateBooking()
        {
            return View();
        }
    }
}
