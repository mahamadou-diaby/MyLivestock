using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Transactions;
using MyLiveStock.DataContrats;

namespace MyLiveStock.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository repository)
        {
            _transactionRepository = repository;
        }

        public List<Transaction> GetTransactions()
        {
            return _transactionRepository.GetTransactions();
        }


        public void CreateTransactions(string description, DateTime date, decimal amount, string type)
        {
            _transactionRepository.CreateTransactions(description, date, amount, type);
        }
    }
}
