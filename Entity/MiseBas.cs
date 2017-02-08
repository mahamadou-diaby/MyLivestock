using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class MiseBas
    {
        public MiseBas()
        {
            Deaths = new List<Death>();
        }

        [Key]
        public string Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Portee { get; set; }
        //[Required]
        public string IdMaleSaillant { get; set; }
        [Required]
        public string Observation { get; set; }
        //[Required]
        public string IdSaillie { get; set; }
        public string MatriculeMisebas { get; set; }        
        public virtual Evenement Evenement { get; set; }
        public virtual List<Death> Deaths { get; set; }
        public bool IsSevrate { get; set; }
    }

    public class Death
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Cause { get; set; }
    }
}
