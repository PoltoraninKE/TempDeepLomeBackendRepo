using DeepLome.WebApi.Models;

namespace DeepLome.Models.Interfaces.Repositories
{
    internal interface IUsersAtEventRepository
    {
        public void Add(UsersAtEvent usersAtEvent);
        public void Delete(UsersAtEvent usersAtEvent);
        public void Update(UsersAtEvent usersAtEvent);
        public UsersAtEvent GetById(int id);
        public UsersAtEvent GetByName(string name);
        public IEnumerable<UsersAtEvent> GetAll();
    }
}
