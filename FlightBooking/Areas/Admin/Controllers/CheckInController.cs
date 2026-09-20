using AutoMapper;
using FlightBooking.DTOs.CheckinDTOs;
using FlightBooking.Entites;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.CheckInServices;
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
        private readonly ICheckInService _checkInService; // ICheckInService arayüzünü kullanmak için checkInService alanını tanımladık.

        public CheckInController(IBookingService bookingService, ICheckInService checkInService)
        {
            _bookingService = bookingService;
            _checkInService = checkInService;
        }

        //public async Task<IActionResult> Index(string id)
        //{
        //    ViewBag.flightNumber= TempData["flightNumber"]; // TempData ile flightNumber değerini View'a taşıyoruz
        //    ViewBag.DepartureTime= TempData["DepartureTime"]; // TempData ile departureTime değerini View'a taşıyoruz
        //    ViewBag.ArrivalTime= TempData["ArrivalTime"]; // TempData ile arrivalTime değerini View'a taşıyoruz
        //    var passenger =await _bookingService.GetPassengerNameByIdAsync(id); // bookingService ile passenger bilgilerini alıyoruz
        //    var pnrNumber=await _bookingService.GetPnrByPassengerIdAsync(id); // bookingService ile pnr bilgilerini alıyoruz
        //    var gate=await _bookingService.GetGateByPassengerIdAsync(id); // bookingService ile gate bilgilerini alıyoruz
        //    ViewBag.Name= passenger.Name; // passenger adını ViewBag ile View'a taşıyoruz
        //    ViewBag.Surname= passenger.Surname; // passenger soyadını ViewBag ile View'a taşıyoruz
        //    ViewBag.PnrNumber= pnrNumber; // pnr bilgisini ViewBag ile View'a taşıyoruz
        //    ViewBag.Gate= gate; // gate bilgisini ViewBag ile View'a taşıyoruz
        //    return View();
        //}
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.FlightNumber = TempData["FlightNumber"];
            ViewBag.DepartureTime = TempData["DepartureTime"];
            ViewBag.ArrivalTime = TempData["ArrivalTime"];
            ViewBag.AirlineCode = TempData["AirlineCode"];          // banner'da kullanılıyor
            ViewBag.DepartureAirportCode = TempData["DepartureAirportCode"];
            ViewBag.DepartureAirportName = TempData["DepartureAirportName"];
            ViewBag.ArrivalAirportCode = TempData["ArrivalAirportCode"];
            ViewBag.ArrivalAirportName = TempData["ArrivalAirportName"];
            ViewBag.BasePrice = TempData["BasePrice"];
            ViewBag.Currency = TempData["Currency"];

            var passenger = await _bookingService.GetPassengerNameByIdAsync(id);
            var pnrNumber = await _bookingService.GetPnrByPassengerIdAsync(id);
            var gate = await _bookingService.GetGateByPassengerIdAsync(id);
         //   var flightId = await _bookingService.GetFlightIDByPassengerIdAsync(id); // 🔥 yeni metod

            ViewBag.Name = passenger.Name;
            ViewBag.Surname = passenger.Surname;
            ViewBag.PassengerName = passenger.Name + " " + passenger.Surname;
            ViewBag.PnrNumber = pnrNumber;
            ViewBag.Pnr = pnrNumber;   // modal'da @ViewBag.Pnr kullanılıyor
            ViewBag.Gate = gate;

            // 🔥 Form için gerekli — hidden field olarak view'a taşınacak
            ViewBag.PassengerId = id;
            ViewBag.FlightId = "6aa839f26b4646f8270761de";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CompleteCheckInDTO completeCheckInDTO)
        {
            await _checkInService.CompleteCheckInAsync(completeCheckInDTO); // checkInService ile check-in işlemini tamamlıyoruz
            return RedirectToAction("Index", "CheckIn", new { area = "Admin" }); // check-in işlemi tamamlandıktan sonra Index sayfasına yönlendiriyoruz               
        }
    }
}
