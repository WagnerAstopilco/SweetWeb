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
    public class PagoRepository : RepositorioBase<Pago>,IPagoRepository
    {
        private readonly ProyectoDisArqContext _db;
        public PagoRepository(ProyectoDisArqContext db) :base(db)
        {
            _db = db;
        }
        public void Actualizar(Pago pago)
        {
            var pagoDB=_db.Pago.FirstOrDefault(p=>p.PagoId == pago.PagoId);
            if(pagoDB is not null)
            {
                pagoDB.Monto_Pendiente = pago.Monto_Pendiente;
                pagoDB.Estado = pago.Estado;
            }
        }
    }
}
