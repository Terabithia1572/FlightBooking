using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu controller'ın Admin Area alanına ait olduğunu belirtir
    public class BookingController : Controller
    {
        public IActionResult CreateBooking() // CreateBooking sayfasını döndürür 
        {
            return View();
        }
        public IActionResult BookingList() // BookingList sayfasını döndürür
        {
            return View();
        }
    }
}
