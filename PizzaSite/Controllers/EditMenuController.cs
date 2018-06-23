using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaSite.Models;
using PizzaSite.Models.Crusts;
using PizzaSite.Models.Cuts;
using PizzaSite.Models.Sauces;
using PizzaSite.Models.Toppings;
using PizzaSite.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaSite.Controllers
{
    
    public class EditMenuController : Controller
    {
        private readonly IMenuItemRepository MIRepo;
        private readonly IToppingRepository TRepo;
        private readonly ISauceRepository SRepo;
        private readonly ICrustRepository CrRepo;
        private readonly ICutRepository CuRepo;
        public EditMenuController(IMenuItemRepository _MIRepo,
            IToppingRepository _TRepo,
            ISauceRepository _SRepo,
            ICrustRepository _CrRepo,
            ICutRepository _CuRepo)
        {
            MIRepo = _MIRepo;
            TRepo = _TRepo;
            SRepo = _SRepo;
            CrRepo = _CrRepo;
            CuRepo = _CuRepo;
        }
        public IActionResult EditMenu()
        {
            EditMenuViewModel emvm = MIRepo.GetEditMenuViewModel();
            return View(emvm);
        }
        //update content
        
        public IActionResult UpdateItem(int id)
        {
            MenuItemViewModel item = MIRepo.GetMenuItemViewModelById(id);
            return View(item);
        }
        

        //delete from menu
        public IActionResult RemoveItem(int id)
        {
            //call MIRepo
            MIRepo.removeMenuItemById(id);
            return RedirectToAction("EditMenu");
        }
        public IActionResult RemoveTopping(int id)
        {
            TRepo.removeToppingById(id);
            return RedirectToAction("EditMenu");
        }
        public IActionResult RemoveSauce(int id)
        {
            SRepo.removeSauceById(id);
            return RedirectToAction("EditMenu");
        }
        public IActionResult RemoveCrust(int id)
        {
            CrRepo.removeCrustById(id);
            return RedirectToAction("EditMenu");
        }
        public IActionResult RemoveCut(int id)
        {
            CuRepo.removeCutById(id);
            return RedirectToAction("EditMenu");
        }


        //create new content
        public IActionResult newMenuItem(int t)
        {
            return View();
        }
        public IActionResult newTopping()
        {
            return View();
        }
        public IActionResult newSauce()
        {
            return View();
        }
        public IActionResult newCut()
        {
            return View();
        }
        public IActionResult newCrust()
        {
            return View();
        }
    }
}
