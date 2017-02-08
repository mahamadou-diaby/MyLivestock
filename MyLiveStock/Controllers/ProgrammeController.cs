using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLiveStock.DataAccess;
using MyLiveStock.DataContrats;
using MyLiveStock.Models;
using MyLiveStock.Service;




namespace MyLiveStock.Controllers
{
    [Authorize]
    public class ProgrammeController : Controller
    {
        private readonly IRabbitService _service;

        public ProgrammeController(IRabbitService service)
        {
            _service = service;
        }
        // GET: Programme
        [Authorize]
        public ActionResult Index()
        {
            var evenement = _service.GetEvenement();
            return View();
        }

        public JsonResult AllEvent()
        {
            var evenement = _service.GetEvenement();            
            List<eventData> data = new List<eventData>();
            foreach(var even in evenement)
            {
                if(even.Title.Contains("Boîte"))
                {
                    data.Add(new eventData { title = even.Title, start = even.Date, backgroundColor = "#00c0ef", borderColor = "#00c0ef" });
                }
                if (even.Title.Contains("Mise"))
                {
                    data.Add(new eventData { title = even.Title, start = even.Date });
                }
                if (even.Title.Contains("Saillie"))
                {
                    data.Add(new eventData { title = even.Title, start = even.Date, backgroundColor = "#00a65a", borderColor = "#00a65a" });
                    }

            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}