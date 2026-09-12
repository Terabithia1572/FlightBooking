using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.DefaultViewComponents
{
    public class _DefaultNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() // Bu metot, ViewComponent'ın render edilmesi sırasında çağrılır ve ViewComponent'ın görünümünü döndürür.
        {
            return View(); // Bu satır, ViewComponent'ın görünümünü döndürür. ViewComponent'ın görünümü, Views/Shared/Components/_DefaultNavbarComponentPartial/Default.cshtml dosyasında bulunur.
        }
    }
}
