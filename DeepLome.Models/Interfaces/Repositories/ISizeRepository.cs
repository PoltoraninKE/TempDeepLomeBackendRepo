using DeepLome.Models.DatabaseModels;

namespace DeepLome.Models.Interfaces.Repositories
{
    internal interface ISizeRepository
    {
        //public void Add(Size size);
        //public void Delete(Size size);
        //public void Update(Size size);
        //public Size GetById(int id);
        //public Size GetByName(string name);
        public IEnumerable<Size> GetAll();
    }
}
