using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Orders.OrderItemSauces
{
    interface IOrderItemSauceRepository
    {
        void AddOrderItemSauce(OrderItemSauce OIS);
    }
}
