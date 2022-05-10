using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Repositories;

namespace DeepLome.Services.Services
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed = false;


        private TrashFindersDBContext dbContext;

        private UsersRepository _usersRepository;
        private TrashRepository _trashRepository;
        private EventRepository _eventRepository;


        public UsersRepository Users() 
        {
            if (_usersRepository == null)
                _usersRepository = new UsersRepository(dbContext);
            return _usersRepository;
        }

        public TrashRepository Trashs()
        {
            if (_trashRepository == null)
                _trashRepository = new TrashRepository(dbContext);
            return _trashRepository;
        }

        public EventRepository Events()
        {
            if (_eventRepository == null)
                _eventRepository = new EventRepository(dbContext);
            return _eventRepository;
        }

        public void SaveChanges() 
        {
            dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
