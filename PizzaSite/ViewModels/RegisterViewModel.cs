using PizzaSite.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.ViewModels
{
    public class RegisterViewModel
    {
        public User customer { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string passConfirm { get; set; }
        public string passMatch { get; set; }

        

    }
}
