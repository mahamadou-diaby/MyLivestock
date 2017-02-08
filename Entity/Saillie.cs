using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Saillie
    {
        public Saillie()
        {
            Evenement = new List<Evenement>();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public DateTime NextMiseBas { get; set; }
        //[Required]
        public string IdMaleSaillant { get; set; }
        [Required]
        public string Observation { get; set; }
        public StatuSaillie status { get; set; }
        public string MatriculeSaillie { get; set; }
        public virtual List<Evenement> Evenement { get; set; }
    }

    public class Evenement
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string MatriculeRabbit { get; set; }
    }

    public enum StatuSaillie
    {
        Reussit = 0,
        EnCour = 1,
        Echoué = 2
    }
}
