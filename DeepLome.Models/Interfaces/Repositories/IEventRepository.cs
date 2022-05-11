using DeepLome.WebApi.Models;

namespace DeepLome.Models.Interfaces.Repositories
{
    public interface IEventRepository
    {
        public void Add(Event event_);
        public void Delete(Event event_);
        public void Update(Event event_);
        public Event? GetById(int id);
        public Event? GetByName(string name);
        public IEnumerable<Event> GetAll();
    }
}
