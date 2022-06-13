using DeepLome.Models.DatabaseModles;
using DeepLome.Models.Interfaces.Repositories;

namespace DeepLome.Models.Repositories
{
    public class EventPhotoRepository: IEventPhotoRepository
    {

        private TrashFindersContext _context;

        public EventPhoto Add(EventPhoto eventPhoto)
        {
            var returnValue = _context.EventPhotos.Add(eventPhoto);
            _context.SaveChanges();
            return returnValue.Entity;
        }

        public void Delete(EventPhoto eventPhoto)
        {
            _context.EventPhotos.Remove(eventPhoto);
            _context.SaveChanges();
        }

        public void Update(EventPhoto eventPhoto)
        {
            _context.EventPhotos.Update(eventPhoto);
            _context.SaveChanges();
        }

        public IEnumerable<EventPhoto> GetAll()
        {
            return _context.EventPhotos;
        }   
    }
}
