using DeepLome.Models.DatabaseModels;

namespace DeepLome.Models.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public void Add(User user);
        public void Delete(User user);
        public void Update(User user);
        public User? GetById(long id);
        public User? GetByName(string name);
        public IEnumerable<User> GetAll();
    }
}
