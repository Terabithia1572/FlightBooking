using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.ViewComponents
{
    public class _AdminTopbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() // Bu metod, ViewComponent'ın render edilmesi sırasında çağrılır ve ViewComponent'ın görünümünü döndürür.
        {
            return View(); // ViewComponent'ın görünümünü döndürür. Bu görünüm, Views/Shared/Components/_AdminTopbarComponentPartial/Default.cshtml dosyasında bulunur.
        }
    }
}
