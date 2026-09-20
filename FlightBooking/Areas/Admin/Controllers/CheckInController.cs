using AutoMapper;
using FlightBooking.Entites;
using FlightBooking.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu area , Admin alanına ait olduğunu belirtir
    public class CheckInController : Controller
    {
        private readonly IMapper _mapper; // IMapper arayüzünü kullanmak için _mapper alanını tanımladık.
        private readonly IMongoCollection<Flight> _flightCollection; // IMongoCollection<Flight> türünde _flightCollection alanını tanımladık. Bu alan, Flight koleksiyonunu temsil eder.
        private readonly IMongoCollection<Booking> _bookingCollection; // IMongoCollection<Booking> türünde _bookingCollection alanını tanımladık. Bu alan, Booking koleksiyonunu temsil eder.

        public CheckInController(IMapper mapper, IDatabaseSettings _databaseSettings) // Constructor'ı FlightService sınıfına ekledik ve IMapper ile IDatabaseSettings parametrelerini aldık.
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // MongoClient sınıfını kullanarak MongoDB bağlantısını oluşturduk.
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // GetDatabase metodu ile belirtilen veritabanını aldık.
            _flightCollection = database.GetCollection<Flight>(_databaseSettings.FlightCollectionName); // GetCollection metodu ile Flight koleksiyonunu aldık.
            _bookingCollection = database.GetCollection<Booking>(_databaseSettings.BookingCollectionName); // GetCollection metodu ile Booking koleksiyonunu aldık.
            _mapper = mapper; // IMapper örneğini _mapper alanına atadık.
        }
        public IActionResult Index(string id)
        {
            ViewBag.flightNumber= TempData["flightNumber"]; // TempData ile flightNumber değerini View'a taşıyoruz
            ViewBag.DepartureTime= TempData["DepartureTime"]; // TempData ile departureTime değerini View'a taşıyoruz
            ViewBag.ArrivalTime= TempData["ArrivalTime"]; // TempData ile arrivalTime değerini View'a taşıyoruz
            return View();
        }
    }
}
