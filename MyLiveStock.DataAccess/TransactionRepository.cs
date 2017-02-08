using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Entity.Transactions;
using MyLiveStock.DataContrats;

namespace MyLiveStock.DataAccess
{
    public class TransactionRepository : ITransactionRepository
    {
        private ContextRepository _contextRepository;

        public TransactionRepository()
        {
            _contextRepository = new ContextRepository();
        }

        // GET METHODES

        public List<Transaction> GetTransactions()
        {
            return _contextRepository.Transactions.ToList();
        }

        // CREATE METHODES

        public void CreateTransactions(string description, DateTime date, decimal amount, string type)
        {
            Transaction transaction = new Transaction
            {
                Id = "trans-" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper(),
                Description = description,
                Date = date,
                Amount = amount,
                Categorie = (TransactionCategorie)Enum.Parse(typeof(TransactionCategorie), type),
                Type = TransactionType.Expense
            };

            _contextRepository.Transactions.Add(transaction);
            _contextRepository.SaveChanges();
        }
    }
}
