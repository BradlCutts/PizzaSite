using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Crusts
{
    public interface ICrustRepository
    {
        IEnumerable<Crust> GetAllCrusts();
        Crust GetCrustById(int ItemId);
        void removeCrustById(int id);
    }
}
