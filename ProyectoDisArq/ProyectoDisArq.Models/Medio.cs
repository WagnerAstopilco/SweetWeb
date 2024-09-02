using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class Medio
    {
        public int MedioId { get; set; }
        public string Tipo { get; set; }
        public string Moneda { get; set; }
        public string? Num_tarjeta { get; set; }
        public string Estado {  get; set; }
        public float Monto { get; set; }
    }
}
