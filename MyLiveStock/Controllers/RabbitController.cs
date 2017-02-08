using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLiveStock.Service;
using MyLiveStock.DataContrats;
using MyLiveStock.Models;
using Entity;
using System.IO;

namespace MyLiveStock.Controllers
{
    [Authorize]
    public class RabbitController : Controller
    {
        private readonly IRabbitService _service;

        public RabbitController(IRabbitService sevice)
        {
            _service = sevice;
        }

        // GET: Rabbit
        [Authorize]
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Productrice = _service.GetProductrices();
            model.Producteur = _service.GetRabbits().Where(r => r.Type == RabbitType.Producteur).ToList();
            return View(model);
        }

        public ActionResult ListeLaperaux()
        {
            var model = _service.GetRabbits().Where(r => r.Type == RabbitType.Laperau).ToList();
            return View(model);
        }

        public ActionResult ListeEngraissement()
        {
            var model = _service.GetRabbits().Where(r => r.Type == RabbitType.Engraissement).ToList();
            return View(model);
        }

        public ActionResult MyJsonData()
        {
            var model = _service.GetRabbits().Where(r => r.Type == RabbitType.Engraissement).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DetailProductrice(string id)
        {
            RabbitViewModel model = new RabbitViewModel();
            model.Productrice = _service.GetProductrice(id);
            var saillies = model.Productrice.Saillie.Where(s => s.status != StatuSaillie.Reussit);
            foreach (var saillie in saillies)
            {
                var normalDate = saillie.NextMiseBas.AddDays(5);
                var differentddate = DateTime.Now.Date.CompareTo(normalDate);
                if (differentddate < 0)
                {
                    saillie.status = StatuSaillie.EnCour;
                }
                else if (differentddate > 0)
                {
                    saillie.status = StatuSaillie.Echoué;
                }
            }

            var maleRabbit = _service.GetRabbits().Where(r => r.Gender == RabbitGender.Mâle && r.Type == RabbitType.Producteur).ToList();
            model.ListeMale = new List<RabbitItem>();
            foreach (var rabbit in maleRabbit)
            {
                RabbitItem item = new RabbitItem
                {
                    Id = rabbit.Matricule,
                    Description = rabbit.Matricule
                };
                model.ListeMale.Add(item);
            }

            ViewBag.listeMale = new SelectList(model.ListeMale, "Id", "Description");
            return View("DetailProductrice", model);
        }

        [HttpGet]
        public ActionResult DetailRabbit(string id)
        {
            var model = _service.GetRabbits().FirstOrDefault(r => r.Matricule == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult PutDeath(string idRabbit, string date, string nombre, string cause, string MatMisebas)
        {            
            var rabbit = _service.GetRabbits().Where(r => r.matriculeMisebas == MatMisebas).ToList();
            var count = Convert.ToInt32(nombre);
            for (int i = 0; i < count; i++)
            {
                _service.DeathNote(idRabbit, MatMisebas, date, cause);
                _service.DeleteRabbit(rabbit[i].Id);
                
            }            
            return RedirectToAction("DetailProductrice", "Rabbit", new { id = idRabbit});
        }

        [HttpPost]
        public ActionResult CreateRabbit(HttpPostedFileBase file ,string matricule, string couleur, string date, string type, string gender, string poids)
        {
            string fileName = "";
            if (file != null && file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(path);
            }
            var id = _service.CreateRabbit(matricule, couleur, date, type, gender, fileName, poids);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddMiseBas(string idRabbit, string date, string portee, string observation, string idSaillie)
        {            
            var porte = Convert.ToInt32(portee);
            var idRab = _service.CreateMiseBas(idRabbit, observation, idSaillie, porte, date, "");
            var model = _service.GetRabbit(idRab);
            return RedirectToAction("DetailProductrice", "Rabbit", new { id = model.Id});
        }

        [HttpPost]
        public ActionResult AddSaillie(string id, string date, string observation, string idMale)
        {
            var idRabbit =_service.CreateSaillie(id, observation, date, idMale);
            var model = _service.GetRabbit(idRabbit);
            return RedirectToAction("DetailProductrice", "Rabbit", new { id = model.Id });
        }

        [HttpPost]
        public ActionResult UpdateRabbit(HttpPostedFileBase file, string id, string date, string matricule, string couleur, string gender, string type, string poids)
        {
            string fileName = string.Empty;
            if (file != null && file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(path);
            }
            var idRabbit = _service.UpdateRabbit(id, matricule, date, type, gender, couleur, fileName, poids);
            var rabbit = _service.GetRabbit(idRabbit);
            if(rabbit.Type == RabbitType.Productrice)
            {
                return RedirectToAction("DetailProductrice", "Rabbit", new { id = rabbit.Id });
            }
            return RedirectToAction("DetailRabbit", "Rabbit", new { id = rabbit.Matricule });
        }

        [HttpPost]
        public ActionResult DeleteSaillie(string idDeleteSaillie, string idRabbit)
        {
            _service.DeleteSaillie(idDeleteSaillie, idRabbit);
            return RedirectToAction("DetailProductrice", "Rabbit", new { id = idRabbit });
        }

        [HttpPost]
        public ActionResult DeleteRabbit(string idRabbit)
        {
            _service.DeleteRabbit(idRabbit);
            return RedirectToAction("Index", "Rabbit");
        }

        [HttpPost]
        public ActionResult Sevrate(string idRabbit, string MatMisebas)
        {
            _service.SevrateYoungRabbit(idRabbit, MatMisebas);
            return RedirectToAction("DetailProductrice", "Rabbit", new { id = idRabbit });
        }
    }
}