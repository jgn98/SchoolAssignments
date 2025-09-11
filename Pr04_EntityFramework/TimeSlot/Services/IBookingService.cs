using TimeSlot.Models;

namespace TimeSlot.Services;

public interface IBookingService
{
    void Add(Booking booking);
    List<Booking> GetAll();
    Booking? GetById(int id);
    void Update(Booking booking);
    void Delete(int id);
    bool Validate(Booking booking);
    
}