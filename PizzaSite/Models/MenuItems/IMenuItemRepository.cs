using PizzaSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public interface IMenuItemRepository
    {
        List<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(int ItemId);
        List<MenuItemViewModel> GetAllMenuItemViewModels();
        MenuItemViewModel GetMenuItemViewModelById(int ItemId);
        EditMenuViewModel GetEditMenuViewModel();
        void removeMenuItemById(int id);
        void removeToppingFromItem(int item, int topping);
    }
}
