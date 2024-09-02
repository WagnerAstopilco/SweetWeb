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
    public class DireccionRepository : RepositorioBase<Direccion>,IDireccionRepository
    {
        private readonly ProyectoDisArqContext _db;
        public DireccionRepository(ProyectoDisArqContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Direccion direccion)
        {
            var direccionDB= _db.Direccion.FirstOrDefault(d=>d.DireccionID==direccion.DireccionID);
            if(direccionDB is not null)
            {
                direccionDB.Tipo_via = direccion.Tipo_via;
                direccionDB.Calle=direccion.Calle;
                direccionDB.Numero=direccion.Numero;
                direccionDB.Referencia=direccion.Referencia;
                direccionDB.DistritoId=direccion.DistritoId;
            }
        }
    }
}
