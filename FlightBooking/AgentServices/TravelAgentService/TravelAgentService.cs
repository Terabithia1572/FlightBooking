
using FlightBooking.AgentServices.OpenAIServices;

namespace FlightBooking.AgentServices.TravelAgentService
{
    public class TravelAgentService : ITravelAgentService
    {
        private readonly IOpenAIService _openAIService;

        public TravelAgentService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task<string> GetRestaurantRecommendationAsync(string cityName)
        {
          var prompt = $"{cityName} şehrine giden bir turist için en iyi restoran önerilerini listele.";
            return await _openAIService.GetResponseAsync(prompt);
        }
    }
}
