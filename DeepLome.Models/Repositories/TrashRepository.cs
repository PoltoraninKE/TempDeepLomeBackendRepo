using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLome.Models.Repositories
{
    public class TrashRepository : ITrashRepository
    {
        TrashFindersDBContext _context;

        public TrashRepository(TrashFindersDBContext context) 
        {
            _context = context;
        }

        public void Add(Trash trash)
        {
            _context.Trashes.Add(trash);
            _context.SaveChanges();
        }

        public void Delete(Trash trash)
        {
            _context.Trashes.Remove(trash);
            _context.SaveChanges();
        }

        public IEnumerable<Trash> GetAll()
        {
            return _context.Trashes;
        }

        public Trash? GetById(int id)
        {
            return _context.Trashes.Select(trash => trash).SingleOrDefault(trash => trash.Id == id);
        }

        public void Update(Trash trash)
        {
            _context.Trashes.Update(trash);
            _context.SaveChanges();
        }
    }
}
