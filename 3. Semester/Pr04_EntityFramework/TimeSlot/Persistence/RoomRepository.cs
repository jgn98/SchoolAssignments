using TimeSlot.Data;
using TimeSlot.Models;

namespace TimeSlot.Persistence;

public class RoomRepository : IRoomRepository
{
    private readonly TimeSlotContext _context;
    
    public void Add(Room room)
    {
        _context.Rooms.Add(room);
        _context.SaveChanges();       
    }

    public void Delete(int id)
    {
        _context.Rooms.Remove(GetById(id));
        _context.SaveChanges();       
    }

    public List<Room> GetAll()
    {
        return _context.Rooms.ToList();
    }

    public Room? GetById(int id)
    {
        return _context.Rooms.FirstOrDefault(x => x.RoomId == id);
    }

    public void Update(Room room)
    {
        _context.Update(room);
    }

    public RoomRepository(TimeSlotContext context)
    {
        _context = context;
    }
}