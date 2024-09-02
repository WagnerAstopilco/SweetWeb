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
    public class InsumoRecetaRepository :RepositorioBase<InsumoReceta>,IInsumoRecetaRepository
    {
        private readonly ProyectoDisArqContext _db;
        public InsumoRecetaRepository(ProyectoDisArqContext db):base(db)
        {
            _db = db;
        }
        public void Actualizar(InsumoReceta insumoReceta)
        {
            var insumoRecetaDB = _db.InsumoReceta.FirstOrDefault(ir => ir.InsumoRecetaId == insumoReceta.InsumoRecetaId);

            if (insumoRecetaDB is not null)
            {
                insumoRecetaDB.InsumoId = insumoReceta.InsumoId;
                insumoRecetaDB.RecetaId = insumoReceta.RecetaId;
                insumoRecetaDB.Cantidad_uso = insumoReceta.Cantidad_uso;
                insumoRecetaDB.Medida_uso=insumoReceta.Medida_uso;
            }
        }
        public IEnumerable<SelectListItem> GetAllDropdownList(string obj)
        {
            if (obj == "Insumo")
                return _db.Insumo.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.InsumoId.ToString()
                });
            return null;
        }
    }
}
