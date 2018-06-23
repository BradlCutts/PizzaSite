using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Orders
{
    interface IOrderItemToppingRepository
    {
        void AddOrderItemTopping(OrderItemTopping OIT);
    }
}
