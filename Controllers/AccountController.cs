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
                .FirstOrDefault(u => u.Username == Username && u.PasswordHash == Password);

            if (user != null)
            { HttpContext.Session.SetString("FirstName", user.FirstName);
                HttpContext.Session.SetString("LastName", user.LastName);
                HttpContext.Session.SetInt32("StaffInfoId", user.StaffInfoId);
                HttpContext.Session.SetString("Role", user.StaffRole.ToString());

                if (user.StaffRole == StaffRole.Employee || user.StaffRole == StaffRole.Optometrists)
                {
                    return RedirectToAction("Staff_Dashboard", "Dashboard");
                }

                else if (user != null && (user.StaffRole == StaffRole.Manager))
                {
                    return RedirectToAction("Manager_Dashboard", "Dashboard"); 
                }

            }

                ViewBag.Error = "Incorrect Username or Password";
            return View();
        }


            public IActionResult Logout()
        {
            HttpContext.Session.Clear(); //clears the session data when the user logs out//
            return View("Login", "Account");
        }
    }

    
    
    
    
    }

