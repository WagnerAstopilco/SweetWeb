using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class Provincia
    {
        public int ProvinciaId { get; set; }
        public string Name { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
    }
}
