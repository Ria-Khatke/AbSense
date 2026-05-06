using System.ComponentModel.DataAnnotations;

namespace AbSense.Models
{
    public enum StaffType
    {
        FullTime = 1,
        PartTime = 2,
        Contractor = 3
    }
    public enum StaffRole
    {
        Employee = 1,
        Manager = 2,
        Admin = 3,
        Optometrists = 4
    }
    public class StaffInfo
    {
        public int StaffInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public StaffType StaffType { get; set; }
        public int AllowedLeaves { get; set; }
        public StaffRole StaffRole { get; set; }
        public bool IsActive { get; set; }



    }

    public enum LeaveType
    {
        General = 1,
        Sick = 2,
        Study = 3
    }
    public enum LeaveStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }


    public class HolidayInfo
    {
        public int HolidayInfoId { get; set; }
        public int staffId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType LeaveType { get; set; }
        public String? Reason { get; set; }
        public LeaveStatus Status { get; set; }
        public int ManagerId { get; set; }
        public String? ManagerComment { get; set; }
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
