using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Cuts
{
    public class CutRepository: ICutRepository
    {
        private readonly AppDbContext _appDbContext;
        public CutRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Cut> GetAllCuts()
        {
            return _appDbContext.Cuts;
        }

        public Cut GetCutById(int ItemId)
        {
            return _appDbContext.Cuts.FirstOrDefault(c => c.Id == ItemId);
        }
        public void removeCutById(int id)
        {
            Cut cut = GetCutById(id);
            _appDbContext.Remove(cut);
            _appDbContext.SaveChanges();
        }
    }
}
