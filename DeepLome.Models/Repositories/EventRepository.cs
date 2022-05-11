using DeepLome.Models.Interfaces.Repositories;
using DeepLome.WebApi.Models;

namespace DeepLome.Models.Repositories
{
    public class EventRepository : IEventRepository
    {
        TrashFindersContext _context;

        public EventRepository(TrashFindersContext context) 
        {
            _context = context;
        }

        public void Add(Event event_)
        {
            _context.Events.Add(event_);
            _context.SaveChanges();
        }

        public void Delete(Event event_)
        {
            _context.Events.Remove(event_);
            _context.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events;
        }

        public Event? GetById(int id)
        {
            return _context.Events.Select(u => u).SingleOrDefault(u => u.Id == id);
        }

        public Event? GetByName(string name)
        {
            return _context.Events.Select(u => u).SingleOrDefault(u => u.EventName == name);
        }

        public void Update(Event event_)
        {
            _context.Events.Update(event_);
            _context.SaveChanges();
        }
    }
}
