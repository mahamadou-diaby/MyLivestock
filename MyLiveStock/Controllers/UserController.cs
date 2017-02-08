using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using MyLiveStock.DataContrats;

namespace MyLiveStock.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService _userServ)
        {
            _userService = _userServ;
        }

        // GET: User
        public ActionResult Index()
        {
            var model = _userService.GetUsers();
            return View(model);
        }

        public ActionResult CreateUser(User user)
        {
            if(ModelState.IsValid)
            {
                _userService.CreateUser(user);
            }
            return RedirectToAction("Index", "User");
        }
    }
}