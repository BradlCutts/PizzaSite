using Microsoft.EntityFrameworkCore;
using PizzaSite.Models.MenuItems;
using PizzaSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly AppDbContext _appDbContext;
        public MenuItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<MenuItem> GetAllMenuItems()
        {
            return _appDbContext.MenuItems
                .Include(mic => mic.MenuItemCrusts)
                    .ThenInclude(cr => cr.Crust)
                .Include(micu => micu.MenuItemCuts)
                    .ThenInclude(cut => cut.Cut)
                .Include(mis => mis.MenuItemSauces)
                    .ThenInclude(sauce => sauce.Sauce)
                .Include(mit => mit.MenuItemToppings)
                    .ThenInclude(topping => topping.Topping)
                .Include(size => size.Sizes).ToList();
        }
        public MenuItem GetMenuItemById(int ItemId)
        {
            return _appDbContext.MenuItems
                .Include(mic => mic.MenuItemCrusts)
                    .ThenInclude(cr => cr.Crust)
                .Include(micu => micu.MenuItemCuts)
                    .ThenInclude(cut => cut.Cut)
                .Include(mis => mis.MenuItemSauces)
                    .ThenInclude(sauce => sauce.Sauce)
                .Include(mit => mit.MenuItemToppings)
                    .ThenInclude(topping => topping.Topping)
                .Include(size => size.Sizes)
                .FirstOrDefault(MI => MI.Id == ItemId); 
        }
        public List<MenuItemViewModel> GetAllMenuItemViewModels()
        {
            List<MenuItemViewModel> menuItemVMs = new List<MenuItemViewModel>();
            var menuItems = this.GetAllMenuItems();

            foreach(var menuItem in menuItems)
            {
                MenuItemViewModel VM = new MenuItemViewModel
                {
                    Id = menuItem.Id,
                    Title = menuItem.Title,
                    ShortDescription = menuItem.ShortDescription,
                    LongDescription = menuItem.LongDescription,
                    ImageUrl = menuItem.ImageUrl,
                    ThumbnailUrl = menuItem.ThumbnailUrl,
                    Type = menuItem.Type,
                    Sizes = new List<Size>(),
                    Crusts = new List<Crust>(),
                    Cuts = new List<Cut>(),
                    Sauces = new List<Sauce>(),
                    Toppings= new List<ToppingVm>()
                };
                foreach (var mit in menuItem.MenuItemToppings)
                {
                    ToppingVm tvm = new ToppingVm
                    {
                        topping = mit.Topping,
                        isSelected = true
                    };
                    VM.Toppings.Add(tvm);
                }
                foreach(var mis in menuItem.MenuItemSauces)
                {
                    VM.Sauces.Add(mis.Sauce);
                }
                foreach(var mic in menuItem.MenuItemCrusts)
                {
                    VM.Crusts.Add(mic.Crust);
                }
                foreach(var mic in menuItem.MenuItemCuts)
                {
                    VM.Cuts.Add(mic.Cut);
                }
                foreach(Size size in menuItem.Sizes)
                {
                    VM.Sizes.Add(size);
                }

                menuItemVMs.Add(VM);
            }

            return menuItemVMs; 
        }
        public MenuItemViewModel GetMenuItemViewModelById(int ItemId)
        {
            var menuItem = GetMenuItemById(ItemId);
            MenuItemViewModel VM = new MenuItemViewModel
            {
                Id = menuItem.Id,
                Title = menuItem.Title,
                ShortDescription = menuItem.ShortDescription,
                LongDescription = menuItem.LongDescription,
                ImageUrl = menuItem.ImageUrl,
                ThumbnailUrl = menuItem.ThumbnailUrl,
                Type = menuItem.Type,
                Sizes = new List<Size>(),
                Crusts = new List<Crust>(),
                Cuts = new List<Cut>(),
                Sauces = new List<Sauce>(),
                Toppings = new List<ToppingVm>()
            };

            foreach (var mit in menuItem.MenuItemToppings)
            {
                ToppingVm topping = new ToppingVm
                {
                    topping = mit.Topping,
                    isSelected = true,
                };
                VM.Toppings.Add(topping);
            }
            foreach (var mis in menuItem.MenuItemSauces)
            {
                VM.Sauces.Add(mis.Sauce);
            }
            foreach (var mic in menuItem.MenuItemCrusts)
            {
                VM.Crusts.Add(mic.Crust);
            }
            foreach (var mic in menuItem.MenuItemCuts)
            {
                VM.Cuts.Add(mic.Cut);
            }
            foreach (var size in menuItem.Sizes)
            {
                VM.Sizes.Add(size);
            }


            return VM;
        }
        public EditMenuViewModel GetEditMenuViewModel()
        {
            EditMenuViewModel emvm = new EditMenuViewModel
            {
                Pizzas = _appDbContext.MenuItems.Where(x => x.Type == "Pizza").ToList(),
                Sides = _appDbContext.MenuItems.Where(x => x.Type == "Side").ToList(),
                Desserts = _appDbContext.MenuItems.Where(x => x.Type == "Dessert").ToList(),
                Drinks = _appDbContext.MenuItems.Where(x => x.Type == "Drink").ToList(),
                Toppings = _appDbContext.Toppings.ToList(),
                Sauces = _appDbContext.Sauces.ToList(),
                Cuts = _appDbContext.Cuts.ToList(),
                Crusts = _appDbContext.Crusts.ToList(),
            };
            return emvm;
        }
        public void removeMenuItemById(int id)
        {
            MenuItem item = GetMenuItemById(id);
            _appDbContext.Remove(item);
            _appDbContext.SaveChanges();
        }
        public void removeToppingFromItem(int item, int topping)
        {
            MenuItemTopping x = _appDbContext.MenuItemToppings.FirstOrDefault(i => i.MenuItemId == item && i.ToppingId == topping);
            _appDbContext.Remove(x);
            _appDbContext.SaveChanges();
        }
       
    }
}
