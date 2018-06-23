using Newtonsoft.Json;
using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PizzaSite.ViewModels
{
    public class MenuItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public List<Crust> Crusts { get; set; }
        public List<Cut> Cuts { get; set; }
        public List<Sauce> Sauces { get; set; }
        public List<ToppingVm> Toppings { get; set; }
        public List<Size> Sizes { get; set; }
        public string Type { get; set; }

       
    }
}
