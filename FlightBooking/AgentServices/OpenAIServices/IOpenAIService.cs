using FlightBooking.DTOs.AgentDTOs;

namespace FlightBooking.AgentServices.OpenAIServices
{
    public interface IOpenAIService
    {
        Task<AgentResponseDTO> GetResponseAsync(string prompt);
    }
}
