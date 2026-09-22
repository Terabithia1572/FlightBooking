namespace FlightBooking.AgentServices.TravelAgentService
{
    public interface ITravelAgentService
    {
         Task<string> GetRestaurantRecommendationAsync(string cityName);
      //  Task<AgentResponseDto> AskAgentAsync(string prompt);
    }
}
