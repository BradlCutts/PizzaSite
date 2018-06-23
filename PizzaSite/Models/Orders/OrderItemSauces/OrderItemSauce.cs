using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Orders
{
    public class OrderItemSauce
    {
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }
        public int SauceId { get; set; }
        public Sauce Sauce { get; set; }
    }
}
