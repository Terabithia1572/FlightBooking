using FlightBooking.DTOs.NoShowDTOs;
using FlightBooking.Services.NoShowServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OverBookingController : Controller
    {
        private readonly NoShowService
            _mongoNoShowService;

        private readonly OverbookingRecommendationService
            _overbookingRecommendationService;

        public OverBookingController(
            NoShowService mongoNoShowService,
            OverbookingRecommendationService
                overbookingRecommendationService)
        {
            _mongoNoShowService = mongoNoShowService;

            _overbookingRecommendationService =
                overbookingRecommendationService;
        }

        public async Task<IActionResult> Index()
        {
            var flights =
                await _mongoNoShowService.GetAllAsync();

            var results = new List<dynamic>();

            foreach (var flight in flights)
            {
                var recommendation =
                    await _overbookingRecommendationService
                        .GenerateRecommendationAsync(
                            flightDate:
                                flight.FlightDate,

                            flightSlot:
                                flight.FlightSlot,

                            passengerCount:
                                flight.BoardedPassenger,

                            capacity:
                                flight.Capacity);

                results.Add(recommendation);
            }

            return View(results);
        }
    }
}