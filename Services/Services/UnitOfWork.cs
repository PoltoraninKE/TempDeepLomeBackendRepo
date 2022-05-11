using DeepLome.Models.Interfaces;
using DeepLome.Models.Interfaces.Repositories;
using DeepLome.WebApi.Models;

namespace DeepLome.Services.Services
{
    public class UnitOfWork :  IUnitOfWork
    {
        private bool _disposed = false;

        private TrashFindersContext _dbContext;

        public IUserRepository Users { get; }
        public IEventRepository Event { get; }

        public UnitOfWork(
            TrashFindersContext dbContext,
            IUserRepository usersRepository,
            IEventRepository eventRepository)
        {
            _dbContext = dbContext;
            Users = usersRepository;
            Event = eventRepository;
        }
        
        public void SaveChanges() 
        {
            _dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
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
