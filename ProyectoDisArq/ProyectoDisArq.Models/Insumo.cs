using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class Insumo
    {
        public int InsumoId{get; set;}

        public string Name { get; set;}

        public float Stock { get; set;}
        public string Unidad_Medida {  get; set;}

        public DateTime UpdatedAt { get; set;}
        public string Descripcion {  get; set;}

        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }
    }
}
