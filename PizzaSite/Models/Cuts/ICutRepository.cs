using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Cuts
{
    public interface ICutRepository
    {
        IEnumerable<Cut> GetAllCuts();
        Cut GetCutById(int ItemId);
        void removeCutById(int id);
    }
}
