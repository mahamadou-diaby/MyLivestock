using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using MyLiveStock.DataContrats;

namespace MyLiveStock.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextRepository _contextrepository;

        public UserRepository()
        {
            _contextrepository = new ContextRepository();
        }

        public string CreateUser(User user)
        {
            try
            {
                user.Id = Guid.NewGuid().ToString();
                user.DateCreated = DateTime.Now;
                user.DateModified = DateTime.Now;
                _contextrepository.Users.Add(user);
                _contextrepository.SaveChanges();
                return user.Id;
            }
            catch(NullReferenceException e)
            {
                return e.Message;
            }          
        }

        public List<User> GetUsers()
        {
            return _contextrepository.Users.ToList();
        }

        public User GetUser(string id)
        {
            return _contextrepository.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _contextrepository.Users.FirstOrDefault(u => u.Username == username);
        }

        public void DeleteUser(string id)
        {
            var user = this.GetUser(id);
            try
            {
                _contextrepository.Users.Remove(user);
            }
            catch(NullReferenceException e)
            {
                // Fix me
            }
        }

        public string UpdateUser(User user)
        {
            try
            {
                var us = this.GetUser(user.Id);
                us.Lastname = user.Lastname;
                us.Firstname = user.Firstname;
                us.Username = user.Username;
                us.Role = user.Role;
                _contextrepository.Users.Add(us);
                _contextrepository.SaveChanges();
                return us.Id;
            }
            catch(NullReferenceException e)
            {
                return e.Message;
            }
        }

        public bool Isvalide(string userName, string password)
        {            
            return null != _contextrepository.Users
                .FirstOrDefault(u => u.Username.ToLower() == userName.ToLower() && u.Password == password);
        }
    }
}
