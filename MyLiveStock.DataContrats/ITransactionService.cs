using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Transactions;

namespace MyLiveStock.DataContrats
{
    public interface ITransactionService
    {
        List<Transaction> GetTransactions();
        void CreateTransactions(string description, DateTime date, decimal amount, string type);
    }
}
