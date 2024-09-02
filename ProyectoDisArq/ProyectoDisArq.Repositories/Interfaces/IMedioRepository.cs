using ProyectoDisArq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Interfaces
{
    public interface IMedioRepository :IRepositorioBase<Medio>
    {
        void Actualizar(Medio medio);
    }
}
