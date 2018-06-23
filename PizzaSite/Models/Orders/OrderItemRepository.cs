using Microsoft.EntityFrameworkCore;
using PizzaSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Orders
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _appDbContext;
        public OrderItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<OrderItem> GetAllOrderItems()
        {
            return _appDbContext.OrderItems;
        }
        public List<OrderItem> GetOrderItemsByOrderId(int Id)
        {
            return _appDbContext.OrderItems
                .Include(size => size.Size)
                .Include(crust => crust.Crust)
                .Include(cut => cut.Cut)
                .Include(oit =>oit.OrderItemToppings)
                .Include(oit => oit.OrderItemSauces)
                .Where(oi => oi.OrderId == Id).ToList();
        }
        public OrderItem GetOrderItemById(int OrderItemId)
        {
            return _appDbContext.OrderItems.FirstOrDefault(oi => oi.Id == OrderItemId);
        }

        public void AddOrderItem(DetailViewModel dvm, int customerId)
        {
            OrderItem orderItem = new OrderItem();

            orderItem.Title = dvm.menuItem.Title;
            orderItem.ShortDescription = dvm.menuItem.ShortDescription;
            orderItem.ImageUrl = dvm.menuItem.ImageUrl;
            orderItem.ThumbnailUrl = dvm.menuItem.ThumbnailUrl;
            orderItem.Type = dvm.menuItem.Type;
            orderItem.Quantity = dvm.Quantity;
            orderItem.SpecialInstructions = dvm.SpecialInstructions;
            orderItem.Status = "Uninitialized";
            orderItem.Size = dvm.menuItem.Sizes.Find(size => size.Id == dvm.SizeId);
            orderItem.Crust = dvm.menuItem.Crusts.Find(crust => crust.Id == dvm.CrustId);
            orderItem.Cut = dvm.menuItem.Cuts.Find(cut => cut.Id == dvm.CutId);
            orderItem.MenuItemId = dvm.menuItem.Id;
            
            orderItem.Price = orderItem.Size.Price;
            //get orderId
            var order = _appDbContext.Orders.Where(s => s.customer.Id == customerId && s.Status == "Not Placed").FirstOrDefault();
            //if none exists create a new one

            if (order == null)
            {
                Order newOrder = new Order();
                newOrder.Status = "Not placed";
                newOrder.customer = _appDbContext.Users.FirstOrDefault(u => u.Id == customerId);
                _appDbContext.Orders.Add(newOrder);
                _appDbContext.SaveChanges();
                order = _appDbContext.Orders.Where(s => s.Status == "Not placed").FirstOrDefault();
            }
            

            //set OrderId
            orderItem.OrderId = order.Id;

            //add orderItem to database
            _appDbContext.OrderItems.Add(orderItem);
            _appDbContext.SaveChanges();
            orderItem = _appDbContext.OrderItems.Where(oi => oi.Status == "Uninitialized").FirstOrDefault();


            foreach (ToppingVm topping in dvm.menuItem.Toppings)
            {
                if(topping.isSelected == true)
                {
                    OrderItemTopping OIT = new OrderItemTopping
                    {
                        OrderItemId = orderItem.Id,
                        ToppingId = topping.topping.Id,

                    };
                    //add to database
                    _appDbContext.OrderItemToppings.Add(OIT);
                }
                

            }
            if(dvm.menuItem.Title == "Custom")
            {
                OrderItemSauce OIS = new OrderItemSauce
                {
                    OrderItemId = orderItem.Id,
                    SauceId = dvm.SauceId,
                };
                _appDbContext.OrderItemSauces.Add(OIS);
            }
            else
            {
                foreach (Sauce sauce in dvm.menuItem.Sauces)
                {
                    OrderItemSauce OIS = new OrderItemSauce
                    {
                        OrderItemId = orderItem.Id,
                        SauceId = sauce.Id,
                    };
                    //add to database
                    _appDbContext.OrderItemSauces.Add(OIS);

                }
            }
            
            _appDbContext.Update(orderItem);
            orderItem.Status = "In Progress";
            _appDbContext.SaveChanges();


        }
        

    }
}
