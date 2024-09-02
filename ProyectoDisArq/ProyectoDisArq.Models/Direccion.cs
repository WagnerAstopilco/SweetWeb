using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class Direccion
    {
        public int DireccionID { get; set; }

        public string Tipo_via { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string? Referencia { get; set; }

        public int DistritoId {  get; set; }
        public Distrito? Distrito { get; set; }
    }
}
