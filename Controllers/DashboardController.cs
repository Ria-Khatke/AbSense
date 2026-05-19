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


            var staff_id = HttpContext.Session.GetInt32("StaffInfoId");

            var balance = abSenseDBcontext.HolidayBalances
            .FirstOrDefault(b => b.StaffInfoId == staff_id);

            ViewBag.AllowedLeaves = balance != null ? balance.TotalAllowance: 0;


            var request = abSenseDBcontext.HolidayInfos;
                var user_requests = request.Where (r=> r.StaffInfoId == staff_id)
                .OrderByDescending(r=> r.CreatedAt)
                .ToList();
            //This let the from data create into a list and organise it by the date created and show the most recent one first

            ViewBag.RemainingLeaves = balance != null ? 
                balance.TotalAllowance - balance.UsedLeaves: 0;

            return View(request);



            return View();
        }

        [HttpPost]

        public IActionResult Book_leave(DateTime StartDate, DateTime EndDate, LeaveType leaveType, string? Reason)
        { 
            var staffId = HttpContext.Session.GetInt32("StaffInfoId");

            if (EndDate < StartDate)
                TempData["Error"] = "End date cannot be more before start date";



            var leave_request = new HolidayInfo
            {
                StaffInfoId = staffId.Value,
                StartDate = StartDate,
                EndDate = EndDate,
                LeaveType = leaveType,
                Reason = Reason,
                Status = LeaveStatus.Pending,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            abSenseDBcontext.HolidayInfos.Add(leave_request);
            abSenseDBcontext.SaveChanges();

            TempData["Success"] = "Leave request submitted successfully.";
            return RedirectToAction("Staff_Dashboard");




        }


    }
}
