using FlightBooking.AgentServices.TravelAgentService;
using FlightBooking.DTOs.AgentDTOs;
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
        [HttpGet]
        public IActionResult AskAgent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AskAgent([FromBody] AgentPromptRequestDTO request)
        {
           var result=await _travelAgentService.AskAgentAsync(request.Prompt);
            return Content(result.Response);
        }

    }
}
