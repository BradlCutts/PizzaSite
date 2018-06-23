using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.MenuItems
{
    public class MenuItemCrust
    {
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int CrustId { get; set; }
        public Crust Crust { get; set; }
    }
}
