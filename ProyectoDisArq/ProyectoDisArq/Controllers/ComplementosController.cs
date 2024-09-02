using Microsoft.AspNetCore.Mvc;
using ProyectoDisArq.Models.ViewModels;
using ProyectoDisArq.Models;
using ProyectoDisArq.Repositories.Interfaces;
using ProyectoDisArq.Utilities;

namespace ProyectoDisArq.Controllers
{
    public class ComplementosController : Controller
    {
        private readonly IUnitWork _unitWork;
        [BindProperty]
        public ComplementoVM complementoVM { get; set; }
        public ComplementosController(IUnitWork unitWork)
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
            ComplementoVM complementoVM = new ComplementoVM()
            {
                Complemento = new Complemento(),
                ListCategorias = _unitWork.Complemento.ObtenerTodosDropdownLista("Categoria"),
                ListRecetas = _unitWork.Complemento.ObtenerTodosDropdownLista("Receta")

            };
            return View(complementoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComplementoVM complementoVM)
        {
            if (ModelState.IsValid)
            {
                await _unitWork.Complemento.AgregarAsync(complementoVM.Complemento);
                await _unitWork.GuardarAsync();
                TempData[DS.Successful] = "Complemento creado correctamente.";
                return RedirectToAction("Index");
            }
            complementoVM.ListCategorias = _unitWork.Complemento.ObtenerTodosDropdownLista("Categoria");
            complementoVM.ListRecetas = _unitWork.Complemento.ObtenerTodosDropdownLista("Receta");
            TempData[DS.Error] = "Error al actualizar el complemento, intente de nuevo.";
            return View(complementoVM);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            complementoVM = new ComplementoVM();
            complementoVM.Complemento = await _unitWork.Complemento.ObtenerPrimeroAsync(filter: c => c.ComplementoId == id, includeProperties: "Categoria,Receta");
            complementoVM.ListCategorias = _unitWork.Complemento.ObtenerTodosDropdownLista("Categoria");
            complementoVM.ListRecetas = _unitWork.Complemento.ObtenerTodosDropdownLista("Receta");
            if (complementoVM is null) return NotFound();
            return View(complementoVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Complemento complemento)
        {
            if (ModelState.IsValid)
            {
                _unitWork.Complemento.Actualizar(complemento);
                await _unitWork.GuardarAsync();

                TempData[DS.Successful] = "Complemento actualizado correctamente.";
                return RedirectToAction("Index");
            }

            TempData[DS.Error] = "Error al actualizar el complemento, intente de nuevo.";
            return View(complemento);
        }
        [HttpGet]
        public async Task<ActionResult> Detail(int? id)
        {
            complementoVM = new ComplementoVM();
            complementoVM.Complemento = await _unitWork.Complemento.ObtenerPrimeroAsync(filter: i => i.ComplementoId == id, includeProperties: "Categoria,Receta");

            return View(complementoVM);
        }
        [HttpPost]
        public async Task<IActionResult> Detail(int complementoId)
        {
            complementoVM = new ComplementoVM();
            complementoVM.Complemento = await _unitWork.Complemento.ObtenerPrimeroAsync(b => b.ComplementoId == complementoId);
            return View(complementoVM);
        }

        #region API para javascript
        /// <summary>
        /// Lista todos los libros registrados
        /// </summary>
        /// <returns>Json</returns>
        public async Task<IActionResult> ListarTodos()
        {
            var complementos = await _unitWork.Complemento.ObtenerTodosAsync(
                includeProperties: "Categoria,Receta",
                orderBy: b => b.OrderByDescending(b => b.ComplementoId),
                isTracking: false);

            return Json(new { data = complementos });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var complementoDB = await _unitWork.Complemento.ObtenerPrimeroAsync(b => b.ComplementoId == id);

            if (complementoDB is null)
                return Json(new { success = false, message = "Error al eliminar el complemento." });

            _unitWork.Complemento.Eliminar(complementoDB);
            await _unitWork.GuardarAsync();
            return Json(new { success = true, message = "Complemento eliminado correctamente." });
        }
        #endregion
    }
}
