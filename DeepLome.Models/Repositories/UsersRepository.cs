using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Interfaces;
using DeepLome.Models.Interfaces.Repositories;

namespace DeepLome.Models.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private TrashFindersDBContext _context;


        public UsersRepository(TrashFindersDBContext context) 
        {
            _context = context;
        }
        
        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Select(u => u);
        }

        public User? GetById(int id)
        {
            return _context.Users.Select(u => u).SingleOrDefault(u => u.Id == id);
        }

        public User? GetByName(string name)
        {
            return _context.Users.Select(u => u).SingleOrDefault(u => u.FirstName == name);
        }

        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}
