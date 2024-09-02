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
    public class ComplementoProductoRepository : RepositorioBase<ComplementoProducto>,IComplementoProductoRepository
    {
        private readonly ProyectoDisArqContext _db;
        public ComplementoProductoRepository(ProyectoDisArqContext db) :base(db)
        {
            _db = db;
        }
        public void Actualizar(ComplementoProducto complementoProducto)
        {
            var complementoProductoDB = _db.ComplementoProducto.FirstOrDefault(cp => cp.ComplementoProductoId == complementoProducto.ComplementoProductoId);
            if(complementoProductoDB is not null)
            {
                complementoProductoDB.ComplementoId=complementoProducto.ComplementoProductoId;
                complementoProductoDB.ProductoId=complementoProducto.ProductoId;
            }
        }
        public IEnumerable<SelectListItem> GetAllDropdownList(string obj)
        {
            if (obj == "Complemento")
                return _db.Complemento.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.ComplementoId.ToString()
                });
            return null;
        }
    }
}
