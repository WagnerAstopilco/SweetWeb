using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class PedidoProductoRepository : RepositorioBase<PedidoProducto>, IPedidoProductoRepository
    {
        private readonly ProyectoDisArqContext _db;
        public PedidoProductoRepository(ProyectoDisArqContext db):base(db)
        {
            _db = db;
        }
        public void Actualizar(PedidoProducto pedidoProducto)
        {
            var pedidoProductoDB = _db.PedidoProducto.FirstOrDefault(cp => cp.PedidoProductoId == pedidoProducto.PedidoProductoId);
            if (pedidoProductoDB is not null)
            {
                pedidoProductoDB.PedidoId = pedidoProducto.PedidoId;
                pedidoProductoDB.ProductoId = pedidoProducto.ProductoId;
            }
        }
        public IEnumerable<SelectListItem> GetAllDropdownList(string obj)
        {
            if (obj == "Pedido")
                return _db.Pedido.Select(x => new SelectListItem
                {
                    Text = x.AppUser.FirstName,
                    Value = x.PedidoId.ToString()
                });
            return null;
        }
    }
}
