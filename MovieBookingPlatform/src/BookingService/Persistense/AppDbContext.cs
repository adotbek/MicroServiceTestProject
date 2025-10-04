using BookingService.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Persistense;

public class AppDbContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
