using PizzaSite.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Paid { get; set; }
        public User customer { get; set; }


    }
}
