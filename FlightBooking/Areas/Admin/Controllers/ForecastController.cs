using FlightBooking.Services.MachineLearningServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu area , Admin alanına ait olduğunu belirtir
    public class ForecastController : Controller
    {
        private readonly MongoFlightDataService _mongoFlightDataService;
        private readonly FlightMlService _flightMlService;

        public ForecastController(FlightMlService flightMlService, MongoFlightDataService mongoFlightDataService)
        {
            _flightMlService = flightMlService;
            _mongoFlightDataService = mongoFlightDataService;
        }

        public async Task<IActionResult> TrainModel()
        {
            var mlData = await _mongoFlightDataService.ConvertToMlDataAsync();
            _flightMlService.Train(mlData);
            ViewBag.Message = "Model başarıyla eğitildi.";
            return View();
        }
    }
}
