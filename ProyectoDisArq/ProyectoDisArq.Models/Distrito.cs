using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class Distrito
    {
        public int DistritoId { get; set; }
        public string Name { get; set; }

        public int ProvinciaId { get; set; }
        public Provincia? Provincia { get; set; }
    }
}
