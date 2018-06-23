using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.MenuItems
{
    public class MenuItemCut
    {
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int CutId { get; set; }
        public Cut Cut { get; set; }
    }
}
