using System.ComponentModel.DataAnnotations;

namespace AbSense.Models
{
    public class StaffInfo
    {
        public int StaffInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string StaffTyep { get; set; }
        public int AllowedLeaves { get; set; }
        public string StaffRole { get; set; }
        public string IsActive { get; set; }



    }

    public class Holidayinfo
    {
        public int HolidayInfoId { get; set; }
        public string Username { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string ManagerName { get; set; }
        public char ManagerComment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class HolidayBalance
    {
        
        public int HolidayBalanceId { get; set; }
        public int HolidayInfoId { get; set; }
        public string Username { get; set; }
        public int AnnualAllowance { get; set; }
        public  int UsedLeaves { get; set; }
        public int RemainingLeaves { get; set; }

    }
    
        
    
}
