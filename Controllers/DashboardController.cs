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
            return View();
        }

    }
}
