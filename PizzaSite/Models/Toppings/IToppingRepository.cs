using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Toppings
{
    public interface IToppingRepository
    {
        IEnumerable<Topping> GetAllToppings();
        Topping GetToppingById(int ItemId);
        void removeToppingById(int id);
    }
}
