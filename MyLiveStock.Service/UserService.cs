using Entity;
using MyLiveStock.DataContrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLiveStock.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userrepository;

        public UserService(IUserRepository _userRepo)
        {
            _userrepository = _userRepo;
        }

        public void CreateUser(User user)
        {
            var us = _userrepository.CreateUser(user);
        }

        public List<User> GetUsers()
        {
            return _userrepository.GetUsers();
        }

        public User GetUser(string id)
        {
            return _userrepository.GetUser(id);
        }

        public void DeleteUser(string id)
        {
            _userrepository.DeleteUser(id);
        }

        public string UpdateUser(User user)
        {
            return _userrepository.UpdateUser(user);
        }
    }
}
