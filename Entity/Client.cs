using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string WorkPhone { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
