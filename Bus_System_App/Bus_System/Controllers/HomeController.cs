using Microsoft.AspNetCore.Mvc;

namespace Bus_System.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
