namespace AbSense.Data
{


    using Microsoft.EntityFrameworkCore;
    using AbSense.Models;
    
    public class AbSenseDBcontext : DbContext // inherits the abilities from dbcontext 
    {
        public AbSenseDBcontext(DbContextOptions<AbSenseDBcontext> options) : base(options) { }

        public DbSet<StaffInfo> User { get; set; }
        public DbSet<Holidayinfo> Holiday { get; set; }
        public DbSet<HolidayBalance> HolidayBalance { get; set; }
    }

}
