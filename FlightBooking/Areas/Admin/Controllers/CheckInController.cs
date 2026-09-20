using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu area , Admin alanına ait olduğunu belirtir
    public class CheckInController : Controller
    {
       
        public IActionResult Index(string id)
        {
            ViewBag.flightNumber= TempData["flightNumber"]; // TempData ile flightNumber değerini View'a taşıyoruz
            return View();
        }
    }
}
