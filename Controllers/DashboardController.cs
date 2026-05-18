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

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(last_name))
            {
                return RedirectToAction("Login", "Account");
                
                
            }
            var user = abSenseDBcontext.Staff
                .FirstOrDefault(u => u.FirstName == name && u.LastName == last_name);


            ViewBag.FirstName = name;
            ViewBag.LastName = last_name;

            ViewBag.AllowedLeaves = user?.TotalAllowance ?? 0;

            return View();
        }

    }
}
