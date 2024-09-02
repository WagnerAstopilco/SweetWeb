using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoDisArq.Models;
using ProyectoDisArq.Repositories.Interfaces;
using ProyectoDisArq.Utilities;

namespace ProyectoDisArq.Controllers
{
    public class RecetasController : Controller
    {
        private readonly IUnitWork _unitWork;

        public RecetasController(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Categorias/Details/5
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _unitWork.Receta.ObtenerPrimeroAsync(filter: c => c.RecetaId == id);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // GET: Categorias/Create
        [HttpGet]
        public IActionResult Create()
        {
            var receta = new Receta();
            return View(receta);
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Receta receta)
        {
            if (ModelState.IsValid)
            {
                await _unitWork.Receta.AgregarAsync(receta);
                await _unitWork.GuardarAsync();
                TempData[DS.Successful] = "Receta creada correctamente";
                return RedirectToAction("Index");
            }
            TempData[DS.Error] = "Error al crear la receta, intente nuevamente";
            return View(receta);
        }

        // GET: Categorias/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _unitWork.Receta.ObtenerAsync(id.GetValueOrDefault());
            if (receta == null)
            {
                return NotFound();
            }
            return View(receta);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Receta receta)
        {
            if (ModelState.IsValid)
            {
                _unitWork.Receta.Actualizar(receta);
                TempData[DS.Successful] = "Receta actualizada correctamente";
                return RedirectToAction("Index");
            }
            TempData[DS.Error] = "Error al actualizar la receta, intente de nuevo";
            return View(receta);
        }
        #region API Javascript
        public async Task<IActionResult> ListarTodos()
        {
            var recetas = await _unitWork.Receta.ObtenerTodosAsync(
                orderBy: b => b.OrderByDescending(b => b.RecetaId),
                isTracking: false);

            return Json(new { data = recetas });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var recetaDB = await _unitWork.Receta.ObtenerAsync(id);

            if (recetaDB is null)
                return Json(new { success = false, message = "Error al eliminar la receta." });

            _unitWork.Receta.Eliminar(recetaDB);
            await _unitWork.GuardarAsync();
            return Json(new { success = true, message = "Receta eliminada correctamente." });
        }
        #endregion
    }
}
