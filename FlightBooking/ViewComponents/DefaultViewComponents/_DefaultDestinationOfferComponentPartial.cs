using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.DefaultViewComponents
{
    public class _DefaultDestinationOfferComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() // Bu metod, ViewComponent'ın çalıştırıldığında çağrılacak olan ana metodudur. Bu metod, ViewComponent'ın görünümünü döndürür.
        {
            return View(); // Bu satır, ViewComponent'ın görünümünü döndürür. View() metodu, varsayılan olarak Views/Shared/Components/_DefaultDestinationOfferComponentPartial/Default.cshtml dosyasını arar ve bu dosyayı döndürür.
        }
    }
}
