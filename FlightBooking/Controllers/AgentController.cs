using FlightBooking.AgentServices.TravelAgentService;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Controllers
{
    public class AgentController : Controller
    {
        private readonly ITravelAgentService _travelAgentService;
        public AgentController(ITravelAgentService travelAgentService)
        {
            _travelAgentService = travelAgentService;
        }

        public async Task<IActionResult> Restaurant(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                return BadRequest("City name is required.");
            }
            var recommendation = await _travelAgentService.GetRestaurantRecommendationAsync(cityName);
            return Ok(recommendation);
        }

    }
}
