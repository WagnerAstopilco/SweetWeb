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
    public class CategoriaRepository : RepositorioBase<Categoria>, ICategoriaRepository
    {
        private readonly ProyectoDisArqContext _db;

        public CategoriaRepository(ProyectoDisArqContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Categoria categoria)
        {
            var categoriaDB = _db.Categoria.FirstOrDefault(c => c.CategoriaId == categoria.CategoriaId);

            if (categoriaDB is not null)
            {
                categoriaDB.Nombre = categoria.Nombre;
                categoriaDB.Descripcion = categoria.Descripcion;
                _db.SaveChanges();
            }
        }
    }
}
