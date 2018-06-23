using PizzaSite.Models;
using PizzaSite.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.ViewModels
{
    public class ProfileViewModel
    {
        public User User { get; set; }
        public List<MenuItem> RecentItems {get; set;}

    }
}
