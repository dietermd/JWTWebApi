using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetUsers()
        {
            var managerRoles = new List<string> { "manager", "employee" };
            var employeeRoles = new List<string> { "employee" };
            return new List<User>
            {
                new User { Id = 1, Username = "manager", Password = "manager@123", Type = "manager", Roles = managerRoles },
                new User { Id = 2, Username = "employee", Password = "employee@123", Type = "employee", Roles = employeeRoles }
            };
        }

        public User GetUser(string username, string password)
        {
            return GetUsers().FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
