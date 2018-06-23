using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaSite.Models;
using PizzaSite.Models.Orders;
using PizzaSite.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaSite.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class EmployeeController : Controller
    {
        public readonly IOrderRepository ORepo;
        public EmployeeController(IOrderRepository _ORepo)
        {
            ORepo = _ORepo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TakeOrder()
        {
            return View();
        }
        public IActionResult Orders()
        {
            TrackerViewModel tvm = ORepo.GetTVMsByStatus();
            return View(tvm);
        }
        public IActionResult Details(int id)
        {
            OrderItemViewModel oivm = ORepo.getOIVMById(id);  
            return View(oivm);
        }
        public IActionResult UpdateStatus(int Id)
        {
            ORepo.UpdateOrderItemStatus(Id);

            OrderItem item = ORepo.getOrderItemById(Id);
            Order order = ORepo.GetOrderById(item.OrderId);
            bool changeStatus = true;
            foreach(OrderItem oi in order.OrderItems)
            {
                if(oi.Status != "Done")
                {
                    changeStatus = false;
                }
            }

            if(changeStatus)
            {
                ORepo.UpdateOrderStatus(order.Id);
            }
            
            //find order based on item
            //check to see if order has any more items that arent done
            //update order status apropriatley
            return RedirectToAction("Orders");
        }
    }
}
