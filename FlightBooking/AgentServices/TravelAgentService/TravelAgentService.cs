
using FlightBooking.AgentServices.OpenAIServices;
using FlightBooking.DTOs.AgentDTOs;

namespace FlightBooking.AgentServices.TravelAgentService
{
    public class TravelAgentService : ITravelAgentService
    {
        private readonly IOpenAIService _openAIService;

        public TravelAgentService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task<AgentResponseDTO> AskAgentAsync(string prompt)
        {
           return await _openAIService.GetResponseAsync(prompt);
        }
    }
}
