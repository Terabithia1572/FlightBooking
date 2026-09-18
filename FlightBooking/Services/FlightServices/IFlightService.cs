using FlightBooking.DTOs.FlightDTOs;
using FlightBooking.DTOs.PassengerDTOs;

namespace FlightBooking.Services.FlightServices
{
    public interface IFlightService
    {
        Task<List<ResultFlightDTO>> GetAllFlightsAsync();
        Task<GetFlightByIDDTO> GetFlightByIdAsync(string id);
        Task CreateFlightAsync(CreateFlightDTO createFlightDto);
        Task DeleteFlightAsync(string id);
        Task UpdateFlightAsync(UpdateFlightDTO updateFlightDto);
        Task<List<PassengerListItemDTO>> GetFlightDetailsWithPassengers(string id);

    }
}
