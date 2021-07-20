using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(string username, string password);
    }
}