using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoDisArq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Interfaces
{
    public interface IInsumoRepository : IRepositorioBase<Insumo>
    {
        void Actualizar(Insumo Insumo);

        IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj);
    }
}
