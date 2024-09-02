using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoDisArq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Interfaces
{
    public interface IMedioPagoRepository : IRepositorioBase<MedioPago>
    {
        void Actualizar(MedioPago medioPago);
        IEnumerable<SelectListItem> GetAllDropdownList(string obj);
    }
}
