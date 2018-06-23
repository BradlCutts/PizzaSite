using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Orders.OrderItemSauces
{
    public class OrderItemSauceRepository: IOrderItemSauceRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderItemSauceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddOrderItemSauce(OrderItemSauce OIS)
        {
            _appDbContext.OrderItemSauces.Add(OIS);
        }
    }
}
