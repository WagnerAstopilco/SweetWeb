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
    public class InsumoRepository : RepositorioBase<Insumo>, IInsumoRepository
    {
        
    private readonly ProyectoDisArqContext _db;
        public InsumoRepository(ProyectoDisArqContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Insumo insumo)
        {
            var insumoDB = _db.Insumo.FirstOrDefault(p => p.InsumoId == insumo.InsumoId);

            if (insumoDB is not null)
            {
                insumoDB.Name= insumo.Name;
                insumoDB.Stock = insumoDB.Stock+insumo.Stock;
                insumoDB.CategoriaId = insumo.CategoriaId;
                insumoDB.UpdatedAt=DateTime.Now;
                insumoDB.Descripcion = insumo.Descripcion;
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
            return null;
        }

    }
}
