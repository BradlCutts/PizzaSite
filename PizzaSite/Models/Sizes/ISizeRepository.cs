using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Sizes
{
    public interface ISizeRepository
    {
        IEnumerable<Size> GetAllSizes();
        Size GetSizeById(int ItemId);
    }
}
