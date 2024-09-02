using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class ComplementoProducto
    {
        public int ComplementoProductoId { get; set; }
        public int ComplementoId { get; set; }
        public Complemento? Complemento { get; set; }
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
