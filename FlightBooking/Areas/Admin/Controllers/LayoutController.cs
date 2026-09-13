using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")] //Area: MVC projesini Admin, Kullanıcı gibi büyük bölümlere ayırmamızı sağlar.
    public class LayoutController : Controller
    {
        public IActionResult AdminLayout()
        {
            return View();
        }
    }
}
