using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class MedioPago
    {
        public int MedioPagoId { get; set; }

        public int MedioId { get; set; }
        public Medio? Medio { get; set; }
        public int PagoId { get; set; }
        public Pago? Pago { get; set; }
    }
}
