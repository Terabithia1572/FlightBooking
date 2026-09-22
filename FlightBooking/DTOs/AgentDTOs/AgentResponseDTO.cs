namespace FlightBooking.DTOs.AgentDTOs
{
    public class AgentResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Response { get; set; }
        public string Model { get; set; }
        public DateTime ResponseTime { get; set; }
        public string Intent { get; set; }
        public string? City { get; set; }
        public WeatherResult? Weather { get; set; }
    }
}
