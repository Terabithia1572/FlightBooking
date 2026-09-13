using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.DefaultViewComponents
{
    public class _DefaultFlightStatusComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() // Bu metot, view component'ın render edilmesi sırasında çağrılır ve view component'ın görünümünü döndürür.
        {
            return View(); // ViewComponent'ın görünümünü döndürür. Bu, view component'ın Razor view dosyasını render eder ve kullanıcıya gösterir. 
        }
    }
}
