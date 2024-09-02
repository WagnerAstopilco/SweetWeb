using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "Los Nombres son requerido")]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Los Apellidos son requerido")]
        [MaxLength(100)]
        public string LastName { get; set; }
        

        [NotMapped] // Existe a nivel de modelo pero no en DB
        public string Role { get; set; }
    }
}
