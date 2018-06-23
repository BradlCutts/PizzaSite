using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaSite.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaSite.Controllers
{
    [Route("UpdateMenu")]
    public class UpdateMenuController : Controller
    {
        // GET: /<controller>/
        private readonly IMenuItemRepository MIRepo;
        public UpdateMenuController(IMenuItemRepository _MIRepo)
        {
            MIRepo = _MIRepo;
        }

        
        [HttpDelete("MenuItems/{Item}/Toppings/{Topping}")]
        public IActionResult RemoveToppingFromItem(int Topping, int Item)
        {
            MIRepo.removeToppingFromItem(Item, Topping);
            return Ok();
        }
    }
}
