using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace MyLiveStock.DataContrats
{
    public interface IUserRepository
    {
        string CreateUser(User user);
        List<User> GetUsers();
        User GetUser(string id);
        User GetUserByUsername(string userneme);
        void DeleteUser(string id);
        string UpdateUser(User user);
        bool Isvalide(string userName, string password);
    }
}
