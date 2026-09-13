using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.BookingViewComponents
{
    public class _BookingTagsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() // Bu metod, ViewComponent'ın render edilmesi sırasında çağrılır ve ViewComponent'ın görünümünü döndürür.
        {
            return View(); // ViewComponent'ın görünümünü döndürür. Bu görünüm, Views/Shared/Components/_BookingTagsComponentPartial/Default.cshtml dosyasında bulunur.
        }
    }
}
