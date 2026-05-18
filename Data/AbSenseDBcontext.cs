using Microsoft.EntityFrameworkCore;
using AbSense.Models;

public class AbSenseDBcontext : DbContext
{
    public AbSenseDBcontext(DbContextOptions<AbSenseDBcontext> options) : base(options) { }

    public DbSet<StaffInfo> Staff { get; set; }
    public DbSet<HolidayInfo> HolidayInfos { get; set; }
    public DbSet<HolidayBalance> HolidayBalances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<StaffInfo>().ToTable("Staff");
        modelBuilder.Entity<StaffInfo>().HasKey(s => s.StaffInfoId);
        
        modelBuilder.Entity<HolidayInfo>().ToTable("HolidayInfo");
        modelBuilder.Entity<HolidayInfo>().HasKey(h => h.HolidayInfoId);
        
        modelBuilder.Entity<HolidayBalance>().ToTable("HolidayBalance");
        modelBuilder.Entity<HolidayBalance>().HasKey(hb => hb.HolidayBalanceId);
    }
}




