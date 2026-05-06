using Microsoft.AspNetCore.Mvc;

namespace AbSense.Controllers
{
    public class User : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
