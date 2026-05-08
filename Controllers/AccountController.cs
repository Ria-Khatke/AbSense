using Microsoft.AspNetCore.Mvc;
using AbSense.Models;
using System.Diagnostics.Eventing.Reader;

namespace AbSense.Controllers
{
    public class AccountController : Controller
    {
        private readonly AbSenseDBcontext abSenseDBcontext;

        public AccountController(AbSenseDBcontext context)
        {
            this.abSenseDBcontext = context;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {

            var user = abSenseDBcontext.Staff
                .FirstOrDefault(u => u.Username == Username && u.Password == Password);

            if (user != null)
            {
                if (user.StaffRole == StaffRole.Manager)
                {
                    return RedirectToAction("Manager_Dashboard");
                }
                else if(user.StaffRole == StaffRole.Admin) 
                    {
                    return RedirectToAction("Admin_Dashboard");
                }
                else
                {
                    return RedirectToAction("Staff_Dashboard");
                }
            }

            ViewBag.Error = "Invalid Input";
            return View();
        }

    
    
    
    
    }


    

}