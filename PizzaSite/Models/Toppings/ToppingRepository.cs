using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Toppings
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly AppDbContext _appDbContext;
        public ToppingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Topping> GetAllToppings()
        {
            return _appDbContext.Toppings;
        }

        public Topping GetToppingById(int ItemId)
        {
            return _appDbContext.Toppings.FirstOrDefault(t => t.Id == ItemId);
        }
        public void removeToppingById(int id)
        {
            Topping topping = GetToppingById(id);
            _appDbContext.Remove(topping);
            _appDbContext.SaveChanges();
        }
    }
}
