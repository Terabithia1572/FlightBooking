using FlightBooking.DTOs.AgentDTOs;

namespace FlightBooking.AgentServices.TravelAgentService
{
    public interface ITravelAgentService
    {
         //Task<string> GetRestaurantRecommendationAsync(string cityName);
       Task<AgentResponseDTO> AskAgentAsync(string prompt);
    }
}
