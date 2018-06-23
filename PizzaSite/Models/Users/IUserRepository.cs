using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models.Users
{
    public interface IUserRepository
    {
        User getUserByEmail(string email);
        User getUserById(int id);
        void createUser(User user);
        void UpdateUser(User user);
        List<User> getEmployees();
        void UpdateAdminStatus(int id);
        void RemoveEmployee(int id);
    }
}
