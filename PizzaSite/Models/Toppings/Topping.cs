using PizzaSite.Models.MenuItems;
using PizzaSite.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class Topping
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<OrderItemTopping> OrderItemToppings { get; set; }
        public virtual IEnumerable<MenuItemTopping> MenuItemToppings { get; set; }


    }
}
