using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }

        public string Name { get; set; }
        public string? Descripcion { get; set; }
        public string Tipo_Masa {  get; set; }
        public string Tamagno {  get; set; }
        public string Forma { get; set; }
        public float Costo_Base { get; set; }
        public string Sabor { get; set; }
        [DefaultValue(1)]
        public int Pisos { get; set; }
        [DefaultValue(1)]
        public int Cantidad { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public int RecetaId { get; set; }
        public Receta? Receta { get; set; }

    }
}
