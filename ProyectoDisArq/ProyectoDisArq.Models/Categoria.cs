using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(5, ErrorMessage = "El nombre no debe tener menos de 5 caracteres")]
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
