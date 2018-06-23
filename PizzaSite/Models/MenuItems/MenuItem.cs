using PizzaSite.Models.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public  IEnumerable<MenuItemCrust> MenuItemCrusts { get; set; }
        public  IEnumerable<MenuItemCut> MenuItemCuts { get; set; }
        public  IEnumerable<MenuItemSauce> MenuItemSauces { get; set; }
        public  IEnumerable<MenuItemTopping> MenuItemToppings { get; set; }
        public string Type { get; set; }
        public  IEnumerable<Size> Sizes { get; set; }

        

    }
}
