using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoDisArq.Models;
using ProyectoDisArq.Persistence;
using ProyectoDisArq.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Implementations
{
    public class ProductoRepository :RepositorioBase<Producto>,IProductoRepository
    {
        private readonly ProyectoDisArqContext _db;

        public ProductoRepository(ProyectoDisArqContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Producto producto)
        {
            var productoDB= _db.Producto.FirstOrDefault(p=>p.ProductoId==producto.ProductoId);

            if (productoDB is not null)
            {
                productoDB.Name = producto.Name;
                productoDB.Descripcion = producto.Descripcion;
                productoDB.Tipo_Masa = producto.Tipo_Masa;
                productoDB.Tamagno = producto.Tamagno;
                productoDB.Forma = producto.Forma;
                productoDB.Costo_Base = producto.Costo_Base;
                productoDB.Sabor = producto.Sabor;
                productoDB.Pisos = producto.Pisos;
                productoDB.Cantidad = producto.Cantidad;
                productoDB.CategoriaId= producto.CategoriaId;
                productoDB.RecetaId= producto.RecetaId;
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
