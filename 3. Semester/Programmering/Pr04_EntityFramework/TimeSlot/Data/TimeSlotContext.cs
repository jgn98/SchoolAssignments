using Microsoft.EntityFrameworkCore;
using TimeSlot.Models;

namespace TimeSlot.Data;

public class TimeSlotContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Room)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.RoomId);
    }
    
    public TimeSlotContext(DbContextOptions<TimeSlotContext> options) : base(options)
    {
    }
}