using FlightBooking.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu controller'ın Admin Area alanına ait olduğunu belirtir
    public class BookingController : Controller
    {
        private readonly IFlightService _flightService;
        public async Task< IActionResult> CreateBooking( string id) // CreateBooking sayfasını döndürür 
        {
            var values= await _flightService.GetFlightByIdAsync(id); // FlightService üzerinden uçuş bilgilerini alır
            ViewBag.id = id;
            ViewBag.FlightNumber = values.FlightNumber;
            ViewBag.DepartureAirportCode = values.DepartureAirportCode;
            ViewBag.DepartureAirportName = values.DepartureAirportName;
            ViewBag.ArrivalAirportCode = values.ArrivalAirportCode;
            ViewBag.ArrivalAirportName = values.ArrivalAirportName;
            ViewBag.DepartureTime = values.DepartureTime;
            ViewBag.ArrivalTime = values.ArrivalTime;
            ViewBag.AirlineCode = values.AirlineCode;
            return View();
        }
        public IActionResult BookingList() // BookingList sayfasını döndürür
        {
            return View();
        }
    }
}
