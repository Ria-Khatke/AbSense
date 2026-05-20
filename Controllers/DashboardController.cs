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


        }

        [HttpPost]

        public IActionResult Book_leave(DateTime StartDate, DateTime EndDate, LeaveType leaveType, string? Reason)
            //creates a method that allows staff to book a leave and store the parameters in the bracket.//
        { 
            var staffId = HttpContext.Session.GetInt32("StaffInfoId");
            //stores the staff id from teh current login session into the variable staffId//
            if (EndDate < StartDate)
            { //error validation to check the end date is not less than start date//
                TempData["Error"] = "End date cannot be more before start date";
                return RedirectToAction("staff_dashboard");

            }



            var leave_request = new HolidayInfo
            //creates a new line in the holiday info database with the rows below and stored in variable leave_request//
            {
                StaffInfoId = staffId.Value, //gets the value stored under staffID row with teh current person logged in //
                StartDate = StartDate,
                EndDate = EndDate,
                LeaveType = leaveType,
                Reason = Reason,
                Status = LeaveStatus.Pending, //status of teh leave starts as pending until the manager changes it to approved or rejected//
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            abSenseDBcontext.HolidayInfos.Add(leave_request);//adds the leave_request to the database and save the changes for real//
            abSenseDBcontext.SaveChanges();

            TempData["Success"] = "Leave request submitted successfully.";
            return RedirectToAction("Staff_Dashboard");
            //shows a message when the leave request is submitted to the database and redirects the user back to the staff dashboard//




        }


    }
}
