using FlightBooking.DTOs.RestaurantDTOs;

namespace FlightBooking.AgentServices.GooglePlacesServices
{
    public interface IGooglePlacesServices
    {
        Task<List<RestaurantDTO>> SearchRestaurantsAsync(string query);
    }
}
