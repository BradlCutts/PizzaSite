using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Sizes
{
    public class SizeRepository : ISizeRepository
    {
        private readonly AppDbContext _appDbContext;
        public SizeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Size> GetAllSizes()
        {
            return _appDbContext.Sizes;
        }

        public Size GetSizeById(int ItemId)
        {
            return _appDbContext.Sizes.FirstOrDefault(s => s.Id == ItemId);
        }
    }
}
