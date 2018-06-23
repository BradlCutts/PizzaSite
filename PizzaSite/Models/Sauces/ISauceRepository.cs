using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Sauces
{
    public interface ISauceRepository
    {
        IEnumerable<Sauce> GetAllSauces();
        Sauce GetSauceById(int ItemId);
        void removeSauceById(int id);
    }
}
