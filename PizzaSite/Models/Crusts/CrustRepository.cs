using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Crusts
{
    public class CrustRepository : ICrustRepository
    {
        private readonly AppDbContext _appDbContext;
        public CrustRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Crust> GetAllCrusts()
        {
            return _appDbContext.Crusts;
        }

        public Crust GetCrustById(int ItemId)
        {
            return _appDbContext.Crusts.FirstOrDefault(c => c.Id == ItemId);
        }
        public void removeCrustById(int id)
        {
            Crust crust = GetCrustById(id);
            _appDbContext.Remove(crust);
            _appDbContext.SaveChanges();
        }
    }
}
