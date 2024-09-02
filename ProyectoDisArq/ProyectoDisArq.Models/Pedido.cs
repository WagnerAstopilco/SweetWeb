using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        public DateTime Creado { get; set; }
        public DateTime Fecha_entrega { get; set; }
        public string Tipo_Venta { get; set; }
        public string Estado { get; set; }

        public string Dni_titular { get; set; }
        public string? Autorizado_Nombres {  get; set; }
        public string? Authorizado_Dni { get; set; }
        public string? Autorizado_Apellidos {  get; set; }

        public string AppUserId {  get; set; }
        public AppUser? AppUser { get; set; }

        public int PagoId {  get; set; }
        public Pago? Pago { get; set; }

        public int DireccionId {  get; set; }
        public Direccion? DireccionEntrega { get; set; }
    }
}
