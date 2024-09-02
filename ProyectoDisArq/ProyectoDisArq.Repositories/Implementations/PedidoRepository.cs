using ProyectoDisArq.Models;
using ProyectoDisArq.Persistence;
using ProyectoDisArq.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Implementations
{
    public class PedidoRepository : RepositorioBase<Pedido>, IPedidoRepository
    {
        private readonly ProyectoDisArqContext _db;

        public PedidoRepository(ProyectoDisArqContext db):base(db)
        {
            _db = db;
        }
        public void Actualizar(Pedido pedido)
        {
            var pedidoDB=_db.Pedido.FirstOrDefault(p=>p.PedidoId == pedido.PedidoId);
            if(pedidoDB is not null)
            {
                pedidoDB.DireccionId = pedido.DireccionId;
                pedidoDB.Authorizado_Dni=pedido.Authorizado_Dni;
                pedidoDB.Autorizado_Apellidos=pedido.Autorizado_Apellidos;
                pedidoDB.Autorizado_Nombres=pedido.Autorizado_Nombres;
                pedidoDB.Estado=pedido.Estado;
                pedidoDB.Dni_titular=pedido.Dni_titular;

            }
        }
    }
}
