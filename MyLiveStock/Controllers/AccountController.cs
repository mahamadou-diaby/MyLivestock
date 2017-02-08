using Entity;
using MyLiveStock.DataContrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MyLiveStock.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public AccountController(IUserRepository _repo, IUserService _serv)
        {
            _userRepository = _repo;
            _userService = _serv;
        }

        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        [HttpGet]        
        public ActionResult Login(string url)
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User user)
        {
            if(_userRepository.Isvalide(user.Username, user.Password))
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Login");
            }
            
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}