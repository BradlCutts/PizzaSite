using PizzaSite.Models.MenuItems;
using PizzaSite.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class Sauce
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<OrderItemSauce> OrderItemSauces { get; set; }
        public virtual IEnumerable<MenuItemSauce> MenuItemSauces { get; set; }
    }
}
