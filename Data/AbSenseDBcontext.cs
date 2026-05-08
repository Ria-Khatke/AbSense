using Microsoft.EntityFrameworkCore;
    using AbSense.Models;


public class AbSenseDBcontext : DbContext // inherits the abilities from dbcontext 
{
    public AbSenseDBcontext(DbContextOptions<AbSenseDBcontext> options) : base(options) { }

    public DbSet<StaffInfo> Staff { get; set; }
    public DbSet<HolidayInfo> Holiday { get; set; }
    public DbSet<HolidayBalance> HolidayBalance { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<StaffInfo>().ToTable("Staff");
        modelBuilder.Entity<StaffInfo>().HasKey(s => s.StaffInfoId);
    }
      }




