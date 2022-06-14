using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Interfaces.Repositories;

namespace DeepLome.Models.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly TrashFindersContext _context;


        public UsersRepository(TrashFindersContext context) 
        {
            _context = context;
        }
        
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User? GetById(long id)
        {
            return _context.Users.Select(u => u).SingleOrDefault(u => u.UserTelegramId == id);
        }

        public User? GetByName(string name)
        {
            return _context.Users.Select(u => u).SingleOrDefault(u => u.FirstName == name);
        }

    }
}
