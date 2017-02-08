using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLiveStock.Models;

namespace MyLiveStock.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public PartialViewResult Navigation()
        {
            var model = new NavigationModel(Request.RawUrl);
            return PartialView("_Navigation", model);
        }

    }
}