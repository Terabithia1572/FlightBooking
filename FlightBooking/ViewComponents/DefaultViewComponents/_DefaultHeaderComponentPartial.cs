using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.DefaultViewComponents
{
    public class _DefaultHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() // Bu metot, ViewComponent'ın render edilmesi sırasında çağrılır ve ViewComponent'ın görünümünü döndürür.
        { 
            return View(); // Bu satır, ViewComponent'ın görünümünü döndürür. ViewComponent'ın görünümü, Views/Shared/Components/_DefaultHeaderComponentPartial/Default.cshtml dosyasında bulunur.
        }
    }
}
