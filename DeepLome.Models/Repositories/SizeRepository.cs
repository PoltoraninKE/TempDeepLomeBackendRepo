using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLome.Models.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        TrashFindersDBContext _context;

        public SizeRepository(TrashFindersDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Size> GetAll()
        {
            return _context.Sizes;
        }
    }
}
