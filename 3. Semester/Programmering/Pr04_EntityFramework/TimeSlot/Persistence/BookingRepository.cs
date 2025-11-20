using Microsoft.EntityFrameworkCore;
using TimeSlot.Data;
using TimeSlot.Models;

namespace TimeSlot.Persistence;

public class BookingRepository : IBookingRepository
{
    private readonly TimeSlotContext _context;
    
    public void Add(Booking booking)
    {
        _context.Bookings.Add(booking);
        _context.SaveChanges();       
    }

    public void Delete(int id)
    {
        _context.Bookings.Remove(GetById(id));
        _context.SaveChanges();       
    }

    public List<Booking> GetAll()
    {
        return _context.Bookings.Include(b => b.Room).ToList();
    }

    public Booking? GetById(int id)
    {
        return _context.Bookings.Include(b => b.Room).FirstOrDefault(b => b.BookingId == id);
    }

    public void Update(Booking booking)
    {
        _context.Update(booking);
        _context.SaveChanges();
    }

    public BookingRepository(TimeSlotContext context)
    {
        _context = context;
    }
}