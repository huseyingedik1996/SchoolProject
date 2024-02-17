using Microsoft.AspNetCore.Mvc;

namespace School.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
