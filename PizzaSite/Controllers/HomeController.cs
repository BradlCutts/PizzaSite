using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaSite.Models;
using PizzaSite.Models.Orders;
using PizzaSite.Models.Users;
using PizzaSite.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository ORepo;
        private readonly IMenuItemRepository MIRepo;
        public HomeController(IOrderRepository _ORepo, IMenuItemRepository _MIRepo)
        {
            ORepo = _ORepo;
            MIRepo = _MIRepo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel
            {
                Suggestions = new List<MenuItem>()
            };
            //if(User.Identity.IsAuthenticated)
            //{
            //    var loggedInUser = HttpContext.User;
            //    string Id = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            //    int UserId = Int32.Parse(Id);
            //    List<Order> orders = ORepo.GetOrdersByUserId(UserId);
                
            //    Dictionary<int, int> d = new Dictionary<int, int>();

            //    foreach (Order order in orders)
            //    {
            //        foreach (OrderItem oi in order.OrderItems)
            //        {
            //            if (d.ContainsKey(oi.MenuItemId))
            //            {
            //                d[oi.MenuItemId] = (d[oi.MenuItemId] + 1);
            //            }
            //            else
            //            {
            //                d.Add(oi.MenuItemId, 1);
            //            }
            //        }
            //    }
            //    if (d.Count >= 3)
            //    {
            //        for (int i = 0; i < 3; i++)
            //        {
            //            int TopItem = d.FirstOrDefault(x => x.Value == d.Values.Max()).Key;
            //            MenuItem item = MIRepo.GetMenuItemById(TopItem);
            //            hvm.Suggestions.Add(item);
            //            d.Remove(TopItem);
            //        }
            //    }
            //    else
            //    {
            //        List<MenuItem> items = MIRepo.GetAllMenuItems();
            //        for(int i = 0; i < 3; i++)
            //        {
            //            hvm.Suggestions.Add(items[i]);
            //        }
                    
                    
            //    }
            //}
            //else
            //{
                List<MenuItem> items = MIRepo.GetAllMenuItems();
                for (int i = 0; i < 3; i++)
                {
                    hvm.Suggestions.Add(items[i]);
                }
            //}
            return View(hvm);
        }
    }
}
