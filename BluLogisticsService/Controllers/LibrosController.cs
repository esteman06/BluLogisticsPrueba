using Microsoft.AspNetCore.Mvc;

namespace BlueLogisticsService.Controllers
{
    public class LibrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
