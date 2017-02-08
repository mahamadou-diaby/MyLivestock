using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Transactions
{
    public class Paiement
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Montant { get; set; }
        public string Description { get; set; }
       

    }

   
}
