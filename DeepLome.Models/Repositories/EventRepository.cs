using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Interfaces.Repositories;

namespace DeepLome.Models.Repositories
{
    public class EventRepository : IEventRepository
    {
        TrashFindersContext _context;

        public EventRepository(TrashFindersContext context) 
        {
            _context = context;
        }

        public Event Add(Event event_)
        {
#warning Криво сохраняется дата
            var createdEvent = _context.Events.Add(event_);
            _context.SaveChanges();
            return createdEvent.Entity;
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
