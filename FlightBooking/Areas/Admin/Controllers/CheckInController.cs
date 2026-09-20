using AutoMapper;
using FlightBooking.Entites;
using FlightBooking.Services.BookingServices;
using FlightBooking.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu area , Admin alanına ait olduğunu belirtir
    public class CheckInController : Controller
    {
       
        private readonly IBookingService _bookingService; // IBookingService arayüzünü kullanmak için _bookingService alanını tanımladık.

        public CheckInController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index(string id)
        {
            ViewBag.flightNumber= TempData["flightNumber"]; // TempData ile flightNumber değerini View'a taşıyoruz
            ViewBag.DepartureTime= TempData["DepartureTime"]; // TempData ile departureTime değerini View'a taşıyoruz
            ViewBag.ArrivalTime= TempData["ArrivalTime"]; // TempData ile arrivalTime değerini View'a taşıyoruz
            var passenger =await _bookingService.GetPassengerNameByIdAsync(id); // bookingService ile passenger bilgilerini alıyoruz
            var pnrNumber=await _bookingService.GetPnrByPassengerIdAsync(id); // bookingService ile pnr bilgilerini alıyoruz
            var gate=await _bookingService.GetGateByPassengerIdAsync(id); // bookingService ile gate bilgilerini alıyoruz
            ViewBag.Name= passenger.Name; // passenger adını ViewBag ile View'a taşıyoruz
            ViewBag.Surname= passenger.Surname; // passenger soyadını ViewBag ile View'a taşıyoruz
            ViewBag.PnrNumber= pnrNumber; // pnr bilgisini ViewBag ile View'a taşıyoruz
            ViewBag.Gate= gate; // gate bilgisini ViewBag ile View'a taşıyoruz
            return View();
        }
    }
}
