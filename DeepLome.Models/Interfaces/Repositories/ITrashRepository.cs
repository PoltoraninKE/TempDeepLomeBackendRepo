using DeepLome.Models.DatabaseModels;

namespace DeepLome.Models.Interfaces.Repositories
{
    internal interface ITrashRepository
    {
        public void Add(Trash trash);
        public void Delete(Trash trash);
        public void Update(Trash trash);
        public Trash GetById(int id);
        public Trash GetByName(string name);
        public IEnumerable<Trash> GetAll();
    }
}
