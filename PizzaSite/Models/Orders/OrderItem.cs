using PizzaSite.Models.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class OrderItem
    {
        public OrderItem()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public Crust Crust { get; set; }
        public Cut Cut { get; set; }
        public IEnumerable<OrderItemSauce> OrderItemSauces { get; set; }
        public IEnumerable<OrderItemTopping> OrderItemToppings { get; set; }
        public Size Size { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public string SpecialInstructions { get; set; }
        public int Quantity { get; set; }
        public  int MenuItemId { get; set; }
        
    }
}
