using Microsoft.AspNetCore.Mvc;
using AbSense.Models;

namespace AbSense.Controllers

{
    public class DashboardController : Controller
    {
        private readonly AbSenseDBcontext abSenseDBcontext;

        public DashboardController(AbSenseDBcontext context)
        {
        this.abSenseDBcontext= context;
        }

        public IActionResult Staff_Dashboard()
        {

            var name = HttpContext.Session.GetString("FirstName");
            var last_name = HttpContext.Session.GetString("LastName");

            ViewBag.FirstName = name;
            ViewBag.LastName = last_name;

            return View();
        }

    }
}
