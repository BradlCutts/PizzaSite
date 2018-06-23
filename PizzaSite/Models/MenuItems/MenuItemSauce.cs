using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.MenuItems
{
    public class MenuItemSauce
    {
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int SauceId { get; set; }
        public Sauce Sauce { get; set; }
    }
}
