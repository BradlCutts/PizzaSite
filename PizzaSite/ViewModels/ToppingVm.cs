using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.ViewModels
{
    public class ToppingVm
    {
        public Topping topping { get; set; }
        public bool isSelected { get; set; }
    }
}
