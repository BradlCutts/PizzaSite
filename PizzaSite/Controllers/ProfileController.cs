using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaSite.Models;
using PizzaSite.Models.Orders;
using PizzaSite.Models.Users;
using PizzaSite.ViewModels;

namespace PizzaSite.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserRepository UserRepo;
        private readonly IOrderRepository ORepo;
        private readonly IMenuItemRepository MIRepo;
        public ProfileController(IUserRepository _UserRepo,
            IOrderRepository _ORepo,
            IMenuItemRepository _MIRepo)
        {
            UserRepo = _UserRepo;
            ORepo = _ORepo;
            MIRepo = _MIRepo;
        }
        public IActionResult Index()
        {
            //get user Id from cookie
            var loggedInUser = HttpContext.User;
            string Id = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            User user = UserRepo.getUserById(Int32.Parse(Id));
            List<Order> orders = ORepo.GetOrdersByUserId(user.Id);
            orders.OrderByDescending(o => o.TimeStamp);
            List<MenuItem> items = new List<MenuItem>();
            foreach (Order order in orders)
            {
                foreach (OrderItem oi in order.OrderItems)
                {
                    MenuItem item = MIRepo.GetMenuItemById(oi.MenuItemId);
                    items.Add(item);
                }
            }

            ProfileViewModel pvm = new ProfileViewModel();
            pvm.User = user;
            pvm.RecentItems = items;

            return View(pvm);
        }

        public IActionResult EditProfile()
        {
            var loggedInUser = HttpContext.User;
            string Id = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            User user = UserRepo.getUserById(Int32.Parse(Id));
            ProfileViewModel pvm = new ProfileViewModel();
            pvm.User = UserRepo.getUserById(user.Id);
            return View(pvm);
        }
        [HttpPost]
        public IActionResult EditProfile(ProfileViewModel pvm)
        {
            var loggedInUser = HttpContext.User;
            string Id = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            User user = UserRepo.getUserById(Int32.Parse(Id));
            user.FirstName = pvm.User.FirstName;
            user.LastName = pvm.User.LastName;
            user.Email = pvm.User.Email;
            user.PhoneNumber = pvm.User.PhoneNumber;
            user.Password = pvm.User.Password;

            UserRepo.UpdateUser(user);

            return RedirectToAction("Index");
        }
    }
}

