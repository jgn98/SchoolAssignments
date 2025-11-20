using TimeSlot.Models;
using TimeSlot.Persistence;

namespace TimeSlot.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public Booking GetById(int id)
    {
        return _bookingRepository.GetById(id)!;
    }
    
    public List<Booking> GetAll()
    {
        var bookings = _bookingRepository.GetAll();
        return bookings;
    }
    
    public void Add(Booking booking)
    {
        if (Validate(booking))
            _bookingRepository.Add(booking);
    }
    
    public void Update(Booking booking)
    {
        if (Validate(booking)) 
            _bookingRepository.Update(booking);
    }
    
    public void Delete(int id)
    {
        _bookingRepository.Delete(id);
    }
    
    public bool Validate(Booking booking)
    {
        if (booking.EndTime <= booking.StartTime)
        {
            return false;
        }


        if (booking.StartTime < DateTime.Now)
        {
            return false;

        }

        var existingBookings = _bookingRepository
            .GetAll()
            .Where(b => b.RoomId == booking.RoomId && b.BookingId != booking.BookingId);

        bool hasOverlap = existingBookings.Any(b =>
            booking.StartTime < b.EndTime && booking.EndTime > b.StartTime);

        if (hasOverlap)
        {
            return false;
        }
        return true;
    }
    
    
    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }
}