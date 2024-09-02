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
    public class MedioPagoRepository :RepositorioBase<MedioPago>, IMedioPagoRepository
    {
        private readonly ProyectoDisArqContext _db;
        public MedioPagoRepository(ProyectoDisArqContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(MedioPago medioPago)
        {
            var medioPagoDB = _db.MedioPago.FirstOrDefault(cp => cp.MedioPagoId == medioPago.MedioPagoId);
            if (medioPagoDB is not null)
            {
                medioPagoDB.MedioId = medioPago.MedioId;
                medioPagoDB.PagoId = medioPago.PagoId;
            }
        }
        public IEnumerable<SelectListItem> GetAllDropdownList(string obj)
        {
            if (obj == "Medio")
                return _db.Medio.Select(x => new SelectListItem
                {
                    Text = x.Tipo,
                    Value = x.MedioId.ToString()
                });
            return null;
        }
    }
}
