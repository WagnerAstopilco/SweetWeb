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
    public class RecetaRepository :RepositorioBase<Receta>,IRecetaRepository
    {
        private readonly ProyectoDisArqContext _db;

        public RecetaRepository(ProyectoDisArqContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Receta receta)
        {
            var recetaDB=_db.Receta.FirstOrDefault(r=>r.RecetaId==receta.RecetaId);
            if(recetaDB is not null)
            {
                recetaDB.Name = receta.Name;
                recetaDB.Preparacion = receta.Preparacion;
                recetaDB.Descripcion=receta.Descripcion;
            }
        }

    }
}
