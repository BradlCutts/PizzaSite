using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.ViewModels
{
    public class CartViewModel
    {
        public CartViewModel()
        {
             
        }
        public List<OrderItem> orderItems { get; set; }
        public bool isEmpty { get; set; }
        public decimal Price { get;  set; }
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }
        public Decimal Tax { get; set; }
        public Decimal Total { get; set; }
        public int OrderId { get; set; }
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14})$", 
            ErrorMessage = "The Credit Card number was not entered in the correct format.")]
        [StringLength(16)]
        public string cardNumber { get; set; }
        public string cardExpirationMonth { get; set; }
        public string cardExpirationYear { get; set;}
        public bool payCash { get; set; }
        public string extra { get; set; }
        

        public void SetTaxTotal()
        {
            Tax = Price / 10;
            Total = Price + Tax;
        }
    }
}
