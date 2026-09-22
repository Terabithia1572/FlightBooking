using FlightBooking.DTOs.AgentDTOs;

namespace FlightBooking.Tools.WeatherTool
{
    public interface IWeatherTool
    {
        Task<WeatherResult> GetWeatherAsync(string city);
    }
}
