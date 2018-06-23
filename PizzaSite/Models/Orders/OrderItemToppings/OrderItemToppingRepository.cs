using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Orders
{
    public class OrderItemToppingRepository: IOrderItemToppingRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderItemToppingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddOrderItemTopping(OrderItemTopping OIT)
        {
            _appDbContext.OrderItemToppings.Add(OIT);
        }
    }
}
