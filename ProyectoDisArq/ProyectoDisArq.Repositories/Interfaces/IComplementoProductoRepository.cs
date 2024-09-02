using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoDisArq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Interfaces
{
    public interface IComplementoProductoRepository :IRepositorioBase<ComplementoProducto>
    {
        void Actualizar(ComplementoProducto complementoProducto);

        IEnumerable<SelectListItem> GetAllDropdownList(string obj);
    }
}
