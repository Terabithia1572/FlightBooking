using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.DefaultViewComponents
{
    public class _DefaultSliderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() // Bu metod, view component'ın render edilmesi sırasında çağrılır ve view component'ın görünümünü döndürür.
        {
            return View(); // ViewComponent'ın varsayılan görünümünü döndürür. Bu, "Views/Shared/Components/_DefaultSliderComponentPartial/Default.cshtml" dosyasında bulunan Razor görünümünü temsil eder.
        }
    }
}
