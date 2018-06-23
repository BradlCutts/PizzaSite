using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.MenuItems
{
    public class MenuItemTopping
    {
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}
