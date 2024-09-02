using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class Receta
    {
        public int RecetaId { get; set; }
        public string Name { get; set; }
        public string? Descripcion {  get; set; }
        public string? Preparacion { get; set; }

    }
}
