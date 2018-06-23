using PizzaSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Orders
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int OrderId);
        Order GetOrderByStatus(string status);
        CartViewModel GetCVM(int userId);
        void PlaceOrder(int id, bool isPaid);
        TrackerViewModel GetTVMsByStatus();
        void removeOrderItemById(int id);
        void removeOrderById(int id);
        CartViewModel GetCVMByOrderId(int id);
        TrackerViewModel GetTVMbyOrderId(int id);
        OrderItem getOrderItemById(int id);
        OrderItemViewModel getOIVMById(int id);
        void UpdateOrderItemStatus(int id);
        void UpdateOrderStatus(int id);
        Order GetOrderForCart(int userId);
        List<Order> GetOrdersByUserId(int id);
    }
}