using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Transactions;
using MyLiveStock.DataContrats;
using System.Globalization;

namespace MyLiveStock.Controllers
{
    [Authorize]
    public class ComptabiliteController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IRabbitService _rabbitService;

        public ComptabiliteController(ITransactionService rep_service, IRabbitService rabbitService)
        {
            _transactionService = rep_service;
            _rabbitService = rabbitService;
        }
        // GET: Comptabilite
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Recette()
        {
            ViewBag.SelRabbit = _rabbitService.GetRabbits().Where(r => r.Type == Entity.RabbitType.Engraissement).Count();
            var model = _transactionService.GetTransactions().Where(t => t.Type == TransactionType.Income).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Depenses()
        {
            var model = _transactionService.GetTransactions().Where(t => t.Type == TransactionType.Expense).ToList();

            return View(model);
        }        

        [HttpPost]
        public ActionResult CreateExpense(string categorie, string date, string description, string amount)
        {
            var montant = Convert.ToDecimal(amount);
            var dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            _transactionService.CreateTransactions(description, dt, montant, categorie);
            return RedirectToAction("Depenses", "Comptabilite");
        }

        [HttpPost]
        public PartialViewResult ExpenseFilter(string categorie, string startDate, string endDate)
        {
            if(!string.IsNullOrWhiteSpace(startDate) && !string.IsNullOrWhiteSpace(endDate))
            {
                var start = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var end = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var categ = (TransactionCategorie)Enum.Parse(typeof(TransactionCategorie), categorie);
                if(categ == TransactionCategorie.Tout)
                {
                    var data = _transactionService.GetTransactions().Where(t => DateIsBiggerOrEqual(t.Date, start, end)).ToList();
                    return PartialView("_ExpenseFilterView", data);
                }
                else
                {
                    var data = _transactionService.GetTransactions().Where(t => t.Categorie == categ && DateIsBiggerOrEqual(t.Date, start, end)).ToList();
                    return PartialView("_ExpenseFilterView", data);
                }                
            }
            var model = _transactionService.GetTransactions().ToList();
            return PartialView("_ExpenseFilterView", model);
        }


        private bool DateIsBiggerOrEqual(DateTime date, DateTime start, DateTime end)
        {
            var result = date >= start && date <= end;
            return result;
        }
    }
}