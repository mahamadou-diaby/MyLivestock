using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        [Required, Display(Name = "Nom")]
        public string Lastname { get; set; }
        [Required, Display(Name = "Prénom")]
        public string Firstname { get; set; }
        [Required, Display(Name = "Nom d'utilisateur")]
        public string Username { get; set; }
        [Required, Display(Name = "Mot de passe")]
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        [Required, Display(Name = "Roles")]
        public Roles Role { get; set; }
    }

    public enum Roles
    {
        Administrateur = 1,
        Gerant = 2,
        Eleveur = 3
    }
}
