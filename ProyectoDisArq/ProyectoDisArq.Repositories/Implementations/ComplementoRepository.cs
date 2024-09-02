using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ComplementoRepository : RepositorioBase<Complemento>, IComplementoRepository
    {
        private readonly ProyectoDisArqContext _db;

        public ComplementoRepository(ProyectoDisArqContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Complemento complemento)
        {
            var complementoDB=_db.Complemento.FirstOrDefault(c=>c.ComplementoId==complemento.ComplementoId);
            if (complementoDB is not null)
            {
                complementoDB.Name = complemento.Name;
                complementoDB.Costo_gramo = complemento.Costo_gramo;
                complementoDB.Descripcion=complemento.Descripcion;
                complementoDB.CategoriaId = complemento.CategoriaId;
                complementoDB.RecetaId=complemento.RecetaId;
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj)
        {
            if (obj == "Categoria")
            {
                return _db.Categoria.Select(x => new SelectListItem
                {
                    Text = x.Nombre,
                    Value = x.CategoriaId.ToString()
                });
            }
            if (obj == "Receta")
            {
                return _db.Receta.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.RecetaId.ToString()
                });
            }
            return null;
        }
    }
}
