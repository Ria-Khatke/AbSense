using AbSense.Data;
using Microsoft.AspNetCore.Mvc;

namespace AbSense.Controllers
{
    public class User : Controller
    {

        private readonly AbSenseDBcontext abSenseDBcontext;

        public User(AbSenseDBcontext context)
        {
            this.abSenseDBcontext = context;
        }

        public IActionResult login()
        {
            return View("Views/login.cshtml");
        }
    }
}
