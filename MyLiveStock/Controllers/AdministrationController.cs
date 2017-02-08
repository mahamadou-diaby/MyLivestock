using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLiveStock.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration
        public ActionResult Parametre()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Parametre(string id)
        {

            return View();
        }

    }
}