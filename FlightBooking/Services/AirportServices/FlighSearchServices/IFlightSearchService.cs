using FlightBooking.DTOs.FlightSearchDTOs;

namespace FlightBooking.Services.AirportServices.FlighSearchServices
{
    public interface IFlightSearchService
    {
        Task<List<FlightCardDTO>> SearchAsync(string fromIata, string toIata, string outboundDate, int adults, string cabin, string currency);
    }
}