
using ProyectoDisArq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Interfaces
{
    public interface IPagoRepository :IRepositorioBase<Pago>
    {
        void Actualizar(Pago pago);
    }
}
