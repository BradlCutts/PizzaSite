using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.ViewModels
{
    public class TrackerViewModel
    {
       public List<OrderViewModel> orders { get; set; }
        public int OrderId { get; set; }
        public bool isEmpty { get; set; }

       
    }
}
