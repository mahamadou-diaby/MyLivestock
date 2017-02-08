using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

namespace MyLiveStock.Models
{
    public class IndexViewModel
    {
        public List<Productrice> Productrice { get; set; }
        public List<Rabbit> Producteur { get; set; }
        public Age Age { get; set; }
    }
}