using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLome.Models.Repositories
{
    public class EventRepository : IEventRepository
    {
        TrashFindersDBContext _context;

        public EventRepository(TrashFindersDBContext context) 
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
