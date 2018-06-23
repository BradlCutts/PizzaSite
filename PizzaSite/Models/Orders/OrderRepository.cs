using Microsoft.EntityFrameworkCore;
using PizzaSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderItemRepository OIRepo;
        private readonly AppDbContext _appDbContext;
        public OrderRepository(AppDbContext appDbContext, IOrderItemRepository _OIRepo)
        {
            _appDbContext = appDbContext;
            OIRepo = _OIRepo;
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return _appDbContext.Orders;
        }
        public Order GetOrderById(int OrderId)
        {
            Order order = _appDbContext.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.Id == OrderId);
            return order;
        }
        public Order GetOrderByStatus(string status)
        {
            return _appDbContext.Orders.FirstOrDefault(o => o.Status == status);
        }
        public Order GetOrderForCart(int userId)
        {
            return _appDbContext.Orders.Include(o => o.OrderItems).FirstOrDefault(o => (o.Status == "Not Placed" && o.customer.Id == userId));
        }
        public List<Order> GetOrdersByStatus(string status)
        {
            return _appDbContext.Orders.Where(o => o.Status == status).ToList();
        }
        public List<Order> GetOrdersByUserId(int id)
        {
            return _appDbContext.Orders
                .Include(o => o.OrderItems).Where(o => o.customer.Id == id).ToList();
        }
        public CartViewModel GetCVMByOrderId(int id)
        {
            Order order = GetOrderById(id);
            CartViewModel cvm = new CartViewModel();
            cvm.Price = 0;
            if (order == null)
            {
                cvm.isEmpty = true;


            }
            else
            {
                cvm.isEmpty = false;
                cvm.OrderId = order.Id;
                cvm.Price = GetOrderPriceByOrderId(order.Id);
                cvm.orderItems = OIRepo.GetOrderItemsByOrderId(cvm.OrderId);
            }
            cvm.SetTaxTotal();
            return cvm;
        }
        public CartViewModel GetCVM(int userId)
        {
            Order order = GetOrderForCart(userId);
            CartViewModel cvm = new CartViewModel();
            cvm.Price = 0;
            if (order == null)
            {
                cvm.isEmpty = true;
            }
            else
            {
                cvm.isEmpty = false;
                cvm.OrderId = order.Id;
                cvm.Price = GetOrderPriceByOrderId(order.Id);
                cvm.orderItems = OIRepo.GetOrderItemsByOrderId(cvm.OrderId);
            }
            cvm.SetTaxTotal();
            return cvm;
        }
        public TrackerViewModel GetTVMbyOrderId(int id)
        {
            TrackerViewModel TVM = new TrackerViewModel();
            TVM.orders = new List<OrderViewModel>();
            Order order = GetOrderById(id);
            if (order == null)
            {
                TVM.isEmpty = true;
            }
            else
            {
                TVM.isEmpty = false;

                OrderViewModel ovm = new OrderViewModel
                {
                    Id = order.Id,
                    OrderItems = OIRepo.GetOrderItemsByOrderId(order.Id),
                    Price = order.Price,
                    Status = order.Status,
                    TimeStamp = order.TimeStamp,
                    Paid = order.Paid,


                };
                ovm.percent = ovm.OrderItems.Count;
                Decimal count = 0;
                foreach (OrderItem item in ovm.OrderItems)
                {

                    if (item.Status != "Done")
                    {
                        count++;
                    }
                }
                //means the order is at 0%
                if (count == 0)
                {
                    ovm.percent = 0;
                }
                else
                {
                    ovm.percent = (int)((count / ovm.percent) * 100);
                }
                TVM.orders.Add(ovm);
            }

            return TVM;
        }
        public TrackerViewModel GetTVMsByStatus()
        {
            TrackerViewModel TVM = new TrackerViewModel();

            TVM.orders = new List<OrderViewModel>();
            List<Order> orders = GetOrdersByStatus("In Progress");
            foreach (Order order in orders)
            {
                OrderViewModel omv = new OrderViewModel
                {
                    Id = order.Id,
                    OrderItems = OIRepo.GetOrderItemsByOrderId(order.Id),
                    Price = order.Price,
                    Status = order.Status,
                    TimeStamp = order.TimeStamp,
                    Paid = order.Paid,


                };
                omv.percent = omv.OrderItems.Count;
                Decimal count = 0;
                foreach (OrderItem item in omv.OrderItems)
                {

                    if (item.Status != "Done")
                    {
                        count++;
                    }
                }
                if (count == omv.percent)
                {
                    omv.percent = 0;
                }
                else
                {
                    omv.percent = (int)((count / omv.percent) * 100);
                    omv.percent = 100 - omv.percent;
                }


                TVM.orders.Add(omv);
            }

            return TVM;
        }
        public void PlaceOrder(int id, bool isPaid)
        {
            Order order = GetOrderById(id);
            _appDbContext.Update(order);
            order.Status = "In Progress";
            order.TimeStamp = DateTime.Now;
            order.Price = GetOrderPriceByOrderId(order.Id);
            order.Paid = !isPaid;
            _appDbContext.SaveChanges();

        }
        public Decimal GetOrderPriceByOrderId(int id)
        {
            Decimal Price = 0;
            List<OrderItem> orderItems = OIRepo.GetOrderItemsByOrderId(id);

            foreach (OrderItem orderItem in orderItems)
            {
                if (orderItem.Title == "Custom")
                {
                    Decimal cost = 0;
                    List<OrderItemTopping> OIT = _appDbContext.OrderItemToppings.Where(oit => oit.OrderItemId == orderItem.Id).ToList();
                    List<Topping> toppings = new List<Topping>();
                    foreach (OrderItemTopping x in OIT)
                    {
                        Topping topping = _appDbContext.Toppings.FirstOrDefault(t => t.Id == x.ToppingId);
                        toppings.Add(topping);
                    }

                    foreach (Topping topping in toppings)
                    {
                        cost += topping.Price;
                    }
                    Price = cost;
                }

                Price += orderItem.Size.Price * orderItem.Quantity;


            }
            return Price;
        }
        public void removeOrderItemById(int id)
        {
            var item = _appDbContext.OrderItems.FirstOrDefault(m => m.Id == id);
            _appDbContext.OrderItems.Remove(item);
            _appDbContext.SaveChanges();

        }
        public OrderItem getOrderItemById(int id)
        {
            return _appDbContext.OrderItems
                 .Include(oi => oi.Cut)
                 .Include(oi => oi.Crust)
                 .Include(oi => oi.Size)
                 .Include(oi => oi.OrderItemSauces)
                 .Include(oi => oi.OrderItemToppings)
                 .FirstOrDefault(i => i.Id == id);
        }
        public void removeOrderById(int id)
        {
            var order = GetOrderById(id);
            var items = _appDbContext.OrderItems
                .Include(size => size.Size)
                .Include(crust => crust.Crust)
                .Include(cut => cut.Cut)
                .Include(oit => oit.OrderItemToppings)
                .Include(oit => oit.OrderItemSauces)
                .Where(oi => oi.OrderId == id).ToList();

            foreach (var item in items)
            {
                removeOrderItemById(item.Id);
            }
            _appDbContext.Orders.Remove(order);
            _appDbContext.SaveChanges();
        }
        public OrderItemViewModel getOIVMById(int id)
        {
            OrderItem item = getOrderItemById(id);
            OrderItemViewModel oivm = new OrderItemViewModel
            {
                Id = item.Id,
                Title = item.Title,
                ShortDescription = item.ShortDescription,
                ImageUrl = item.ImageUrl,
                ThumbnailUrl = item.ThumbnailUrl,
                Crust = item.Crust,
                Cut = item.Cut,
                Size = item.Size,
                Type = item.Type,
                Toppings = new List<Topping>(),
                Sauces = new List<Sauce>(),
                SpecialInstructions = item.SpecialInstructions

            };
            foreach (OrderItemTopping oit in item.OrderItemToppings)
            {
                Topping topping = _appDbContext.Toppings.FirstOrDefault(t => t.Id == oit.ToppingId);
                oivm.Toppings.Add(topping);

            }
            foreach (OrderItemSauce ois in item.OrderItemSauces)
            {
                Sauce sauce = _appDbContext.Sauces.FirstOrDefault(s => s.Id == ois.SauceId);
                oivm.Sauces.Add(sauce);
            }

            return oivm;
        }
        public void UpdateOrderItemStatus(int id)
        {
            OrderItem item = getOrderItemById(id);
            _appDbContext.OrderItems.Update(item);
            if(item.Status == "Waiting")
            {
                item.Status = "In Progress";
            }
            else if(item.Status == "In Progress")
            {
                item.Status = "Done";
            }
            _appDbContext.SaveChanges();
        }
        public void UpdateOrderStatus(int id)
        {
            Order order = GetOrderById(id);
            _appDbContext.Orders.Update(order);
            if(order.Status == "In Progress")
            {
                order.Status = "Ready";
            }
            else if(order.Status == "Ready")
            {
                order.Status = "Received";

            }
            _appDbContext.SaveChanges();
        }
        
    }
}
