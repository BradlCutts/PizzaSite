using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaSite.Models.Orders;
using PizzaSite.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaSite.Controllers
{
    public class CartController : Controller
    {
        private readonly IOrderRepository ORepo;
        public CartController(IOrderRepository _ORepo)
        {
            ORepo = _ORepo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var loggedInUser = HttpContext.User;
            string userId = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            CartViewModel cvm = ORepo.GetCVM(Int32.Parse(userId));
            return View(cvm);
        }
        [HttpPost]
        public IActionResult Index(CartViewModel cvm)
        {
           
            return RedirectToAction("Checkout");
        }

        public IActionResult Checkout()
        {
            var loggedInUser = HttpContext.User;
            string userId = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            CartViewModel cvm = ORepo.GetCVM(Int32.Parse(userId));
            return View(cvm);
        }
        [HttpPost]
        public IActionResult Checkout(CartViewModel cvm)
        {
            if(ModelState.IsValid)
            {
                var loggedInUser = HttpContext.User;
                string userId = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
                CartViewModel orderInfo = ORepo.GetCVM(Int32.Parse(userId));
                ORepo.PlaceOrder(orderInfo.OrderId, false);
                return RedirectToAction("Confirmation", new { id = orderInfo.OrderId });
            }
            else
            {
                return View(cvm);
            }
            
        }
        public IActionResult unPaid(int Id)
        {
            
            ORepo.PlaceOrder(Id, true);
            return RedirectToAction("Confirmation", new { id = Id });


        }
        public IActionResult removeItem(int id)
        {
            ORepo.removeOrderItemById(id);

            return RedirectToAction("Index");
        }

        public IActionResult removeAll(int id)
        {
            ORepo.removeOrderById(id);
            return RedirectToAction("Index");
        }
        public IActionResult Confirmation(int id)
        {
            ConfirmationViewModel cvm = new ConfirmationViewModel { OrderNumber = id };
            return View(cvm);
        }
            
    }
}
