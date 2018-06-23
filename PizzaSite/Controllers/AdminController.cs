using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaSite.Models;
using PizzaSite.Models.Users;
using PizzaSite.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaSite.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class AdminController : Controller
    {
        public readonly IUserRepository UserRepo;
        public readonly IMenuItemRepository MIRepo;
        public AdminController(IUserRepository _UserRepo, IMenuItemRepository _MIRepo)
        {
            UserRepo = _UserRepo;
            MIRepo = _MIRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ManageEmployees()
        {
            EmployeesViewModel evm = new EmployeesViewModel();
            evm.Employees = UserRepo.getEmployees();
            return View(evm);
        }
        public IActionResult changeAdminStatus(int id)
        {
            UserRepo.UpdateAdminStatus(id);
            return RedirectToAction("ManageEmployees");
        }
        public IActionResult RemoveEmployee(int id)
        {
            UserRepo.RemoveEmployee(id);
            return RedirectToAction("ManageEmployees");
        }
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(RegisterViewModel rvm)
        {
            bool match = true;
            if (rvm.passConfirm != rvm.customer.Password)
            {
                match = false;
                rvm.passMatch = "The passwords did not match.";
            }

            if (ModelState.IsValid && match)
            {
                User user = UserRepo.getUserByEmail(rvm.customer.Email);
                if (user == null)
                {
                    UserRepo.createUser(rvm.customer);
                    return RedirectToAction("ManageEmployees");
                }
            }

            return View(rvm);
        }

    }
}
