using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Transactions
{
    public class Commande
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public List<Rabbit> Rabbits { get; set; }
        public List<Paiement> Paiements { get; set; }
        public Client Client { get; set; }
    }
}
