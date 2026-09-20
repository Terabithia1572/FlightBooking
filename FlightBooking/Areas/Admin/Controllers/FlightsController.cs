using FlightBooking.DTOs.FlightDTOs;
using FlightBooking.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")] //Area: MVC projesini Admin, Kullanıcı gibi büyük bölümlere ayırmamızı sağlar.
    public class FlightsController : Controller
    {
        private readonly IFlightService _flightService; // IFlightService arayüzünü kullanmak için _flightService alanını tanımladık.

        public FlightsController(IFlightService flightService) // Constructor'ı FlightsController sınıfına ekledik ve IFlightService parametresini aldık.
        {
            _flightService = flightService; // IFlightService örneğini _flightService alanına atadık.
        }

        public async Task<IActionResult> FlightList() // FlightList metodunu implement ettik. Tüm uçuşları listelemek için kullanılır.
        {
            var values = await _flightService.GetAllFlightsAsync(); // IFlightService arayüzünü kullanarak tüm uçuşları aldık.
            return View(values); // Aldığımız uçuşları View'e gönderdik.
        }
        [HttpGet]
        public IActionResult CreateFlight()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFlight(CreateFlightDTO createFlightDto) // CreateFlight metodunu implement ettik. Uçuş oluşturma işlemi için CreateFlightDTO parametresini alır.
        {
            if (ModelState.IsValid) // ModelState'in geçerli olup olmadığını kontrol ettik.
            {
                await _flightService.CreateFlightAsync(createFlightDto); // IFlightService arayüzünü kullanarak yeni uçuşu oluşturduk.
                return RedirectToAction("FlightList"); // Uçuş oluşturulduktan sonra FlightList sayfasına yönlendirdik.
            }
            return View(createFlightDto); // ModelState geçerli değilse, aynı sayfada formu tekrar gösterdik.
        }
        public async Task<IActionResult> FlightDetail(string id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            var passengers = await _flightService.GetFlightDetailsWithPassengers(id);

            ViewBag.FlightNumber = flight?.FlightNumber ?? "—";
            ViewBag.AirlineCode = flight?.AirlineCode ?? "—";
            ViewBag.DepartureAirportCode = flight?.DepartureAirportCode ?? "—";
            ViewBag.ArrivalAirportCode = flight?.ArrivalAirportCode ?? "—";
            ViewBag.DepartureTime = flight?.DepartureTime;   // DateTime? olarak gider
            ViewBag.ArrivalTime = flight?.ArrivalTime;
            ViewBag.TotalSeats = flight?.TotalSeats ?? 0;
            ViewBag.Status = flight?.Status ?? "—";

            TempData["FlightNumber"] = flight.FlightNumber;
            TempData["DepartureTime"] = flight.DepartureTime;
            TempData["ArrivalTime"] = flight.ArrivalTime;

            //  var passenger = await _bookingService.GetPassengerNameByIdAsync(id);


            //TempData["PassengerName"] = passengers.Select(x => x.Name).FirstOrDefault();

            return View(passengers);
        }
    }
}
