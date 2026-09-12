using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.DefaultViewComponents
{
    public class _DefaultHeadComponentPartial: ViewComponent // Bu sınıf, ViewComponent'ı temsil eder ve ViewComponent'ın görünümünü döndürmek için Invoke() metodunu içerir.
    {
        public IViewComponentResult Invoke() // Bu metot, ViewComponent'ın render edilmesi sırasında çağrılır ve ViewComponent'ın görünümünü döndürür.
        {
            return View(); // Bu satır, ViewComponent'ın görünümünü döndürür. ViewComponent'ın görünümü, Views/Shared/Components/_DefaultHeadComponentPartial/Default.cshtml dosyasında bulunur.
        }
    }
}
