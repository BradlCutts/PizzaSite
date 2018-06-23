using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaSite.Models.Orders;
using PizzaSite.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaSite.Controllers
{
    
    public class TrackerController : Controller
    {
        public readonly IOrderRepository ORepo;
        public TrackerController(IOrderRepository _ORepo)
        {
            ORepo = _ORepo;
        }

            // GET: /<controller>/
            public IActionResult Index()
        {
            TrackerViewModel tvm = new TrackerViewModel();
            return View(tvm);
        }
        [HttpPost]
        public IActionResult Report(TrackerViewModel tvm)
        {
            tvm = ORepo.GetTVMbyOrderId(tvm.OrderId);
            return View(tvm);
        }
    }
}
