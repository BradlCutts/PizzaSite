using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PizzaSite.Models.Users;
using PizzaSite.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository UserRepo;
        public AccountController(IUserRepository userRepository)
        {
            UserRepo = userRepository;
        }


        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel lvm)
        {
            User user = UserRepo.getUserByEmail(lvm.Email);
            if(user == null)
            {
                return View(lvm);
            }
            else
            {
                if(user.Password == lvm.password)
                {
                    loginUser(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(lvm);
                }
                
            }


            
              
            
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public  IActionResult Register(RegisterViewModel rvm)
        {
            bool match = true;
            if(rvm.passConfirm != rvm.customer.Password)
            {
                match = false;
                rvm.passMatch = "The passwords did not match.";
            }

            if (ModelState.IsValid && match )
            {
                User user = UserRepo.getUserByEmail(rvm.customer.Email);
                if(user == null)
                {
                    rvm.customer.Role = "Customer";
                    UserRepo.createUser(rvm.customer);
                    user = UserRepo.getUserByEmail(rvm.customer.Email);
                    loginUser(user);
                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View(rvm);
            
        }
        private async void loginUser(User user)
        {
            var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
        }
        public IActionResult EmployeeLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EmployeeLogin(LoginViewModel lvm)
        {
            User user = UserRepo.getUserById(lvm.Id);
            if (user == null)
            {
                return View(lvm);
            }
            else
            {
                if (user.Password == lvm.password)
                {
                    loginUser(user);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    return View(lvm);
                }

            }





            
        }
       public IActionResult EditProfile(int id)
        {
            return View();
        }
    }
}
