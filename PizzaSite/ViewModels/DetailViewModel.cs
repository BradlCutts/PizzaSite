using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.ViewModels
{
    public class DetailViewModel
    {
        public MenuItemViewModel menuItem { get; set; }
        public string SpecialInstructions { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Quantity { get; set; }
        public int SizeId { get; set; }
        public int CutId { get; set; }
        public int CrustId { get; set; }
        public int SauceId { get; set; }
        public int test { get; set; }

        public DetailViewModel(MenuItemViewModel VM)
        {
            
            menuItem = VM;
            test = menuItem.Id;
        }


        public DetailViewModel()
        {

        }
    }
}
