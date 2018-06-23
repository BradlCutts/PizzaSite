using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int percent { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Paid { get; set; }
    }
}
