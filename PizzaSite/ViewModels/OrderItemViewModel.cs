using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public Crust Crust { get; set; }
        public Cut Cut { get; set; }
        public List<Sauce> Sauces { get; set; }
        public List<Topping> Toppings { get; set; }
        public Size Size { get; set; }
        public string Type { get; set; }
        public string SpecialInstructions { get; set; }

    }
}
