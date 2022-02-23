using DeepLome.Models.DatabaseModels;

namespace DeepLome.Models.Interfaces.Repositories
{
    internal interface IUserRepository
    {
        public void Add(User user);
        public void Delete(User user);
        public void Update(User user);
        public User? GetById(int id);
        public User? GetByName(string name);
        public IEnumerable<User> GetAll();
    }
}
