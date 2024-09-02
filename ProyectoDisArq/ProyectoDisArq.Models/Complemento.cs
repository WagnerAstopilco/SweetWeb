using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class Complemento
    {
        public int ComplementoId { get; set; }
        public string Name { get; set; }
        public string? Descripcion { get; set; }
        public float Costo_gramo {  get; set; }
        
        public int CategoriaId {  get; set; }
        public Categoria? Categoria { get; set; }
        public int? RecetaId { get; set; }
        public Receta? Receta { get; set; }

    }
}
