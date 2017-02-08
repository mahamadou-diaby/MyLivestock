using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Productrice : Rabbit
    {
        public virtual List<MiseBas> MiseBas { get; set; }
        public virtual List<Saillie> Saillie { get; set; }
        
    }
}
