using DeepLome.Models.DatabaseModels;

namespace DeepLome.Models.Interfaces.Repositories
{
    public interface IEventPhotoRepository
    {
        public EventPhoto Add(EventPhoto eventPhoto);
        public void Delete(EventPhoto eventPhoto);
        public void Update(EventPhoto eventPhoto);
        public IEnumerable<EventPhoto> GetAll();
    }
}
