using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Orders
{
    public class OrderItemTopping
    {
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}
