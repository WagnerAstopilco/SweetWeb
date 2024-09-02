using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class Pago
    {
        public int PagoId { get; set; }
        [Required]
        public float Monto_Pendiente {  get; set; }
        public string Estado {  get; set; }
    }
}
