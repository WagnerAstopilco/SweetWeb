using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ProyectoDisArq.Models.ViewModels
{
    public class InsumoVM
    {
        public Insumo Insumo { get; set; }
        public IEnumerable<SelectListItem>? ListCategorias { get; set; }
    }
}
