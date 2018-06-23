using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.ViewModels
{
    public class EditMenuViewModel
    {
        public List<MenuItem> Pizzas;
        public List<MenuItem> Sides;
        public List<MenuItem> Desserts;
        public List<MenuItem> Drinks;
        public List<Topping> Toppings;
        public List<Sauce> Sauces;
        public List<Cut> Cuts;
        public List<Crust> Crusts;

    }
}
