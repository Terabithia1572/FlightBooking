
namespace FlightBooking.AgentServices.TravelAgentService
{
    public class TravelAgentService : ITravelAgentService
    {
        public async Task<string> GetRestaurantRecommendationAsync(string cityName)
        {
           return $"Şu an {cityName} şehrinde popüler restoranlar hakkında bilgi veremiyorum, ancak size genel önerilerde bulunabilirim. Örneğin, {cityName} şehrinde deniz ürünleri restoranları ve yerel mutfak deneyimleri oldukça popülerdir. Ayrıca, şehir merkezinde bulunan kafeler ve sokak lezzetleri de ziyaretçilerin ilgisini çekmektedir.";
        }
    }
}
