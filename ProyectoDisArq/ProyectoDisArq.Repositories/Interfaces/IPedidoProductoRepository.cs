using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoDisArq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Interfaces
{
    public interface IPedidoProductoRepository :IRepositorioBase<PedidoProducto>
    {
        void Actualizar(PedidoProducto producto);
        IEnumerable<SelectListItem> GetAllDropdownList(string obj);
    }
}
