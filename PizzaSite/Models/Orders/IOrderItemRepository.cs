using PizzaSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Orders
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> GetAllOrderItems();
        OrderItem GetOrderItemById(int Id);
        void AddOrderItem(DetailViewModel dvm, int customerId);
        List<OrderItem> GetOrderItemsByOrderId(int Id);
    }
}
