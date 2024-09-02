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
    public class MedioRepository : RepositorioBase<Medio>, IMedioRepository
    {
        private readonly ProyectoDisArqContext _db;
        public MedioRepository(ProyectoDisArqContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Medio medio)
        {
            var medioDB = _db.Medio.FirstOrDefault(p => p.MedioId == medio.MedioId);
            if (medioDB is not null)
            {
                medioDB.Estado = medio.Estado;
            }
        }
    }
}
