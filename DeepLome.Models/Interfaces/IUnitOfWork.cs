using DeepLome.Models.Interfaces.Repositories;

namespace DeepLome.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }

        public IEventRepository Event { get; }
        public void SaveChanges();
        public void Dispose();
        public void Dispose(bool disposing);
    }
}