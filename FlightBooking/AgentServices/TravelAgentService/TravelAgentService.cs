
using FlightBooking.AgentServices.OpenAIServices;
using FlightBooking.AgentServices.PromptBuilders;
using FlightBooking.DTOs.AgentDTOs;

namespace FlightBooking.AgentServices.TravelAgentService
{
    public class TravelAgentService : ITravelAgentService
    {
        private readonly IOpenAIService _openAIService;
        private readonly ITravelPromptBuilder _promptBuilder;

        public TravelAgentService(IOpenAIService openAIService, ITravelPromptBuilder promptBuilder)
        {
            _openAIService = openAIService;
            _promptBuilder = promptBuilder;
        }

        public async Task<AgentResponseDTO> AskAgentAsync(string prompt)
        {
        //   return await _openAIService.GetResponseAsync(prompt);
        var finalPrompt= _promptBuilder.BuildPrompt(prompt);
            return await _openAIService.GetResponseAsync(finalPrompt);
        }
    }
}
