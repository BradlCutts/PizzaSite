using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaSite.Models;
using PizzaSite.Models.Crusts;
using PizzaSite.Models.Cuts;
using PizzaSite.Models.Orders;
using PizzaSite.Models.Sauces;
using PizzaSite.Models.Sizes;
using PizzaSite.Models.Toppings;
using PizzaSite.ViewModels;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaSite.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IOrderItemRepository _OIRepo;
      

        public MenuController (IMenuItemRepository menuItemRepository, IOrderItemRepository OIRepo)
        {
            _menuItemRepository = menuItemRepository;
            _OIRepo = OIRepo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
             
            var MenuViewModel = new MenuViewModel()
            {
                MenuItems = _menuItemRepository.GetAllMenuItemViewModels()
        };

            return View(MenuViewModel);
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var menuItemVM = _menuItemRepository.GetMenuItemViewModelById(id);
            if(menuItemVM == null)
            {
                return NotFound();
            }
            DetailViewModel detailViewModel = new DetailViewModel(menuItemVM);

            return View(detailViewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Details(DetailViewModel dvm)
        {
            if(ModelState.IsValid)
            {
                dvm.menuItem = _menuItemRepository.GetMenuItemViewModelById(dvm.test);

                var loggedInUser = HttpContext.User;
                string userId = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
                _OIRepo.AddOrderItem(dvm, Int32.Parse(userId));
            }
            else
            {
                return View(dvm);
            }

            



            return RedirectToAction("AddedToCart");
        }
        [Authorize]
        public IActionResult Custom(int id)
        {
            var menuItemVM = _menuItemRepository.GetMenuItemViewModelById(id);
            foreach(ToppingVm tvm in menuItemVM.Toppings)
            {
                tvm.isSelected = false;
            }
            if (menuItemVM == null)
            {
                return NotFound();
            }
            DetailViewModel customViewModel = new DetailViewModel(menuItemVM);
            return View(customViewModel);
        }
        [Authorize]

        [HttpPost]
        public IActionResult Custom(DetailViewModel dvm)
        {
            List<ToppingVm> extra = dvm.menuItem.Toppings;
            dvm.menuItem = _menuItemRepository.GetMenuItemViewModelById(dvm.test);
            dvm.menuItem.Toppings = extra;
            var loggedInUser = HttpContext.User;
            string userId = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            _OIRepo.AddOrderItem(dvm, Int32.Parse(userId));



            return RedirectToAction("AddedToCart");
        }
        [Authorize]

        public IActionResult AddedToCart()
        {
            return View();
        }
    }
}
