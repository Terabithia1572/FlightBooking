using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.ViewComponents
{
    public class _AdminSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() // Bu metod, ViewComponent'ın render edilmesi sırasında çağrılır ve ViewComponent'ın görünümünü döndürür.
        {
            return View(); // ViewComponent'ın görünümünü döndürür. Bu görünüm, Views/Shared/Components/_AdminSidebarComponentPartial/Default.cshtml dosyasında bulunur.
        }
    }
}
