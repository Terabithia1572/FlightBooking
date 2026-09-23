namespace FlightBooking.DTOs.RestaurantDTOs
{
    public class RestaurantDTO
    {
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Rating { get; set; }
        public int? UserRatingCount { get; set; }
        public string PriceLevel { get; set; }
        public string GoogleMapsUrl { get; set; }
    }
}
