using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Sauces
{
    public class SauceRepository: ISauceRepository
    {
        private readonly AppDbContext _appDbContext;
        public SauceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Sauce> GetAllSauces()
        {
            return _appDbContext.Sauces;
        }
        public Sauce GetSauceById(int ItemId)
        {
            return _appDbContext.Sauces.FirstOrDefault(s => s.Id == ItemId);
        }
        public void removeSauceById(int id)
        {
            Sauce sauce = GetSauceById(id);
            _appDbContext.Remove(sauce);
            _appDbContext.SaveChanges();
        }
    }
}
