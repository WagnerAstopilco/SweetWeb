using Microsoft.AspNetCore.Mvc;
using ProyectoDisArq.Models;
using ProyectoDisArq.Models.ViewModels;
using ProyectoDisArq.Repositories.Interfaces;
using ProyectoDisArq.Utilities;

namespace ProyectoDisArq.Controllers
{
    public class InsumosController : Controller
    {
        private readonly IUnitWork _unitWork;
        [BindProperty]
        public InsumoVM insumoVM { get; set; }
        public InsumosController(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            InsumoVM insumoVM = new InsumoVM()
            {
                Insumo = new Insumo(),
                ListCategorias = _unitWork.Insumo.ObtenerTodosDropdownLista("Categoria")
            };
            return View(insumoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsumoVM insumoVM)
        {
            if (ModelState.IsValid)
            {
                await _unitWork.Insumo.AgregarAsync(insumoVM.Insumo);
                await _unitWork.GuardarAsync();
                TempData[DS.Successful] = "Insumo creado correctamente.";
                return RedirectToAction("Index");
            }
            insumoVM.ListCategorias = _unitWork.Insumo.ObtenerTodosDropdownLista("Categoria");
            TempData[DS.Error] = "Error al actualizar el insumo, intente de nuevo.";
            return View(insumoVM);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            insumoVM = new InsumoVM();
            insumoVM.Insumo = await _unitWork.Insumo.ObtenerPrimeroAsync(filter: i => i.InsumoId == id, includeProperties: "Categoria");
            insumoVM.ListCategorias = _unitWork.Insumo.ObtenerTodosDropdownLista("Categoria");
            if (insumoVM is null) return NotFound();
            return View(insumoVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                _unitWork.Insumo.Actualizar(insumo);
                await _unitWork.GuardarAsync();

                TempData[DS.Successful] = "Insumo actualizado correctamente.";
                return RedirectToAction("Index");
            }

            TempData[DS.Error] = "Error al actualizar el insumo, intente de nuevo.";
            return View(insumo);
        }
        [HttpGet]
        public async Task<ActionResult> Detail(int? id)
        {
            insumoVM = new InsumoVM();
            insumoVM.Insumo = await _unitWork.Insumo.ObtenerPrimeroAsync(filter: i => i.InsumoId == id, includeProperties: "Categoria");

            return View(insumoVM);
        }
        [HttpPost]
        public async Task<IActionResult> Detail(int insumoId)
        {
            insumoVM = new InsumoVM();
            insumoVM.Insumo = await _unitWork.Insumo.ObtenerPrimeroAsync(b => b.InsumoId == insumoId);            
            return View(insumoVM);
        }

        #region API para javascript
        /// <summary>
        /// Lista todos los libros registrados
        /// </summary>
        /// <returns>Json</returns>
        public async Task<IActionResult> ListarTodos()
        {
            var insumos = await _unitWork.Insumo.ObtenerTodosAsync(
                includeProperties: "Categoria",
                orderBy: b => b.OrderByDescending(b => b.InsumoId),
                isTracking: false);

            return Json(new { data = insumos });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var insumoDB = await _unitWork.Insumo.ObtenerPrimeroAsync(b => b.InsumoId == id);

            if (insumoDB is null)
                return Json(new { success = false, message = "Error al eliminar el insumo." });

            _unitWork.Insumo.Eliminar(insumoDB);
            await _unitWork.GuardarAsync();
            return Json(new { success = true, message = "Insumo eliminado correctamente." });
        }
        
        #endregion
    }
}
