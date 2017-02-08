using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entity
{
    public class Rabbit
    {
        [Key]
        public string Id { get; set; }        
        [Required]
        public RabbitGender Gender { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public RabbitType Type { get; set; }
        public string Color { get; set; }
        public string Matricule { get; set; }        
        public string IdPere { get; set; }
        public string IdMere { get; set; }
        public string PictureName { get; set; }
        public string matriculeMisebas { get; set; }
        public string Age { get; set; }
        public int Poids { get; set; }
        
    }


    public enum RabbitType
    {
        Producteur = 0,
        Productrice = 1,
        Laperau = 2,
        Engraissement = 3
    }

    public enum RabbitGender
    {
        Mâle = 0,
        Femelle = 1
    }
    
}
