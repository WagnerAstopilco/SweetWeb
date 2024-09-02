using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoDisArq.Persistence;
using ProyectoDisArq.Repositories.Interfaces;
using ProyectoDisArq.Models;
using ProyectoDisArq.Utilities;

namespace ProyectoDisArq.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly IUnitWork _unitWork;

        public CategoriasController(IUnitWork unitWork)
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

            var categoria = await _unitWork.Categoria.ObtenerPrimeroAsync(filter: c=>c.CategoriaId==id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        [HttpGet]
        public IActionResult Create()
        {
            var categoria = new Categoria();
            return View(categoria);
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _unitWork.Categoria.AgregarAsync(categoria);
                await _unitWork.GuardarAsync();
                TempData[DS.Successful] = "Categoría creada correctamente";
                return RedirectToAction("Index");
            }
            TempData[DS.Error] = "Error al crear la categoría, intente nuevamente";
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _unitWork.Categoria.ObtenerAsync(id.GetValueOrDefault());
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _unitWork.Categoria.Actualizar(categoria);
                TempData[DS.Successful] = "Categoría actualizada correctamente";
                return RedirectToAction("Index");
            }
            TempData[DS.Error] = "Error al actualizar la categoría, intente de nuevo";
            return View(categoria);
        }
        #region API Javascript
        public async Task<IActionResult> ListarTodos()
        {
            var categorias = await _unitWork.Categoria.ObtenerTodosAsync(
                orderBy: b => b.OrderByDescending(b => b.CategoriaId),
                isTracking: false);

            return Json(new { data = categorias });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var publisherDB = await _unitWork.Categoria.ObtenerAsync(id);

            if (publisherDB is null)
                return Json(new { success = false, message = "Error al eliminar la categoría." });

            _unitWork.Categoria.Eliminar(publisherDB);
            await _unitWork.GuardarAsync();
            return Json(new { success = true, message = "Categoria eliminada correctamente." });
        }
        #endregion

    }
}
