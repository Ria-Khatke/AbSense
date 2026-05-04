namespace AbSense.Data
{
    using AbSense.Models;
    using Microsoft.EntityFrameworkCore;
    public class AbSenseDBcontext : DbContext // inherits the abilities from dbcontext 
    {
        public AbSenseDBcontext(DbContextOptions<AbSenseDBcontext> options) : base(options) { }

        public DbSet<staff_info> User { get; set; }
    }
}
