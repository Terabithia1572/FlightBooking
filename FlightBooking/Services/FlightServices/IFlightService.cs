using FlightBooking.DTOs.FlightDTOs;

namespace FlightBooking.Services.FlightServices
{
    public interface IFlightService
    {
        Task<List<ResultFlightDTO>> GetAllFlightsAsync();
        Task<GetFlightByIDDTO> GetFlightByIdAsync(string id);
        Task CreateFlightAsync(CreateFlightDTO createFlightDto);
        Task DeleteFlightAsync(string id);
        Task UpdateFlightAsync(UpdateFlightDTO updateFlightDto);
        
    }
}
