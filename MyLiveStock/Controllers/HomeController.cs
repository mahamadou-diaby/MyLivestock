using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLiveStock.DataContrats;

namespace MyLiveStock.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRabbitService _rabbitService;

        public HomeController(IRabbitService rabbitService)
        {
            _rabbitService = rabbitService;
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Rabbitcount = _rabbitService.GetRabbits().Count();
            return View();
        }
    }
}