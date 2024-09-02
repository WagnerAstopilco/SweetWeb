using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class InsumoReceta
    {
        public int InsumoRecetaId { get; set; }

        public int RecetaId { get; set; }
        public Receta? Receta { get; set; }
        public int InsumoId { get; set; }
        public Insumo? Insumo { get; set; }

        public float Cantidad_uso {  get; set; }
        public string Medida_uso { get; set; }
    }
}
