namespace AbSense.Models
{
    public class staff_info
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string staff_type { get; set; }
        public int allowed_leaves { get; set; }
        public string staff_role { get; set; }
        public string is_active { get; set; }



    }

    public class holiday_info
    {
        public int holiday_id { get; set; }
        public string username { get; set; }
        public char start_date { get; set; }
        public char end_date { get; set; }
        public string leave_type { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
        public string manager_name { get; set; }
        public string manager_comment { get; set; }
        public char created_at { get; set; }
        public char updated_at { get; set; }
    }

    public class holiday_balance_info
    {
        public int holiday_id { get; set; }
        public string username { get; set; }
        public int annual_allowance { get; set; }
        public  int used_leaves { get; set; }
        public int remaining_leaves { get; set; }

    }
    
        
    
}
