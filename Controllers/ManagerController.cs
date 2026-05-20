using Microsoft.AspNetCore.Mvc;
using AbSense.Models;
namespace AbSense.Controllers
{
    public class ManagerController : Controller
    {
        private readonly AbSenseDBcontext abSenseDBcontext;

        public ManagerController(AbSenseDBcontext context)
        {
            this.abSenseDBcontext = context;
        }

        public IActionResult Manager_Dashboard()
        {

            return View("Manager_Dashboard");

        }
    }
}