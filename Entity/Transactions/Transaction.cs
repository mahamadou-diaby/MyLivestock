using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Transactions
{
    public class Transaction
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public TransactionCategorie Categorie { get; set; }
    }

    public enum TransactionType
    {
        Income = 0,
        Expense = 1
    }

    public enum TransactionCategorie
    {
        Tout = 0,
        Nourriture = 1,
        Sante = 2,
        Construction = 3,
        Autre = 4
    }
}
