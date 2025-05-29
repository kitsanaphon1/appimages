using Microsoft.AspNetCore.Mvc;

namespace WebAppProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
