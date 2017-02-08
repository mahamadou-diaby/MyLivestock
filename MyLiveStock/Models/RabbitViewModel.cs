using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

namespace MyLiveStock.Models
{
    public class RabbitViewModel
    {
        public Rabbit Rabbit { get; set; }
        public Productrice Productrice { get; set; }
        public List<RabbitItem> ListeMale { get; set; }        
        
    }

    public class RabbitItem
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

    public class eventData
    {
        public string title { get; set; }
        public string start { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
    }
}