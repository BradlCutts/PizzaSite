using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Users
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public  User getUserByEmail(string email)
        {
            return appDbContext.Users.FirstOrDefault(u => u.Email == email);
        }
        public User getUserById(int id)
        {
            return appDbContext.Users.FirstOrDefault(u => u.Id == id);
        }
        public void createUser(User user)
        {
            appDbContext.Users.Add(user);
            appDbContext.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            User old = getUserById(user.Id);
            appDbContext.Users.Update(old);
            old = user;
            appDbContext.SaveChanges();
        }
        public List<User> getEmployees()
        {
            return appDbContext.Users.Where(u => u.Role == "Admin" || u.Role == "Employee").ToList();
        }
        public void UpdateAdminStatus(int id)
        {
            User employee = getUserById(id);
            appDbContext.Update(employee);
            if(employee.Role == "Admin")
            {
                employee.Role = "Employee";
            }
            else if(employee.Role == "Employee")
            {
                employee.Role = "Admin";
            }
            appDbContext.SaveChanges();
        }
        public void RemoveEmployee(int id)
        {
            User employee = getUserById(id);
            appDbContext.Remove(employee);
            appDbContext.SaveChanges();
        }
    }
}
