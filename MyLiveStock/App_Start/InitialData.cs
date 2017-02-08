using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyliveStock.core;
using Autofac;
using MyLiveStock.DataContrats;
using Entity;

namespace MyLiveStock.App_Start
{
    public class InitialData
    {
        public static void UserInitializeData()
        {
            var username = "mahamadou.diaby";
            var userRepository = ServiceLocator.Curent.Contenair.Resolve<IUserRepository>();
            if(userRepository.GetUserByUsername(username) == null)
            {
                User user = new User {
                    Lastname = "Diaby",
                    Firstname = "Mahamadou",
                    Username = "mahamadou.diaby",
                    Password = "neissa",
                    Role = Roles.Administrateur
                };
                userRepository.CreateUser(user);
            }
        }
    }
}