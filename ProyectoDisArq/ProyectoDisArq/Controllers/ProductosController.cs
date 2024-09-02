using Microsoft.AspNetCore.Mvc;
using ProyectoDisArq.Models;
using ProyectoDisArq.Models.ViewModels;
using ProyectoDisArq.Repositories.Interfaces;
using ProyectoDisArq.Utilities;

namespace ProyectoDisArq.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IUnitWork _unitWork;
        [BindProperty]
        public ProductoVM productoVM { get; set; }
        public ProductosController(IUnitWork unitWork)
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
            ProductoVM productoVM = new ProductoVM()
            {
                Producto = new Producto(),
                ListCategorias = _unitWork.Complemento.ObtenerTodosDropdownLista("Categoria"),
                ListRecetas = _unitWork.Complemento.ObtenerTodosDropdownLista("Receta")

            };
            return View(productoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoVM productoVM)
        {
            if (ModelState.IsValid)
            {
                await _unitWork.Producto.AgregarAsync(productoVM.Producto);
                await _unitWork.GuardarAsync();
                TempData[DS.Successful] = "Producto creado correctamente.";
                return RedirectToAction("Index");
            }
            productoVM.ListCategorias = _unitWork.Complemento.ObtenerTodosDropdownLista("Categoria");
            productoVM.ListRecetas = _unitWork.Complemento.ObtenerTodosDropdownLista("Receta");
            TempData[DS.Error] = "Error al crear el producto, intente de nuevo.";
            return View(productoVM);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            productoVM = new ProductoVM();
            productoVM.Producto = await _unitWork.Producto.ObtenerPrimeroAsync(filter: c => c.ProductoId == id, includeProperties: "Categoria,Receta");
            productoVM.ListCategorias = _unitWork.Complemento.ObtenerTodosDropdownLista("Categoria");
            productoVM.ListRecetas = _unitWork.Complemento.ObtenerTodosDropdownLista("Receta");
            if (productoVM is null) return NotFound();
            return View(productoVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductoVM productoVM)
        {
            if (ModelState.IsValid)
            {
                _unitWork.Producto.Actualizar(productoVM.Producto);
                await _unitWork.GuardarAsync();
                TempData[DS.Successful] = "Producto actualizado correctamente.";
                return RedirectToAction("Index");
            }
            productoVM.ListCategorias = _unitWork.Complemento.ObtenerTodosDropdownLista("Categoria");
            productoVM.ListRecetas = _unitWork.Complemento.ObtenerTodosDropdownLista("Receta");
            return View(productoVM);
        }
        [HttpGet]
        public async Task<ActionResult> Detail(int? id)
        {
            productoVM = new ProductoVM();
            productoVM.Producto = await _unitWork.Producto.ObtenerPrimeroAsync(filter: i => i.ProductoId == id, includeProperties: "Categoria,Receta");

            return View(productoVM);
        }
        [HttpPost]
        public async Task<IActionResult> Detail(int productoId)
        {
            productoVM = new ProductoVM();
            productoVM.Producto = await _unitWork.Producto.ObtenerPrimeroAsync(b => b.ProductoId == productoId);
            return View(productoVM);
        }
        public async Task<IActionResult> Home()
        {
            var productos = await _unitWork.Producto.ObtenerTodosAsync();
            return View(productos);
        }
        public async Task<IActionResult> Tortas()
        {
            var tortas = await _unitWork.Producto.ObtenerTodosAsync(filter:x=>x.Categoria.Nombre=="Torta");
            return View(tortas);
        }
        public async Task<IActionResult> Chessecakes()
        {
            var chessecakes = await _unitWork.Producto.ObtenerTodosAsync(filter: x => x.Categoria.Nombre == "Chessecake");
            return View(chessecakes);
        }
        public async Task<IActionResult> Pies()
        {
            var pies = await _unitWork.Producto.ObtenerTodosAsync(filter: x => x.Categoria.Nombre == "Piess");
            return View(pies);
        }
        public async Task<IActionResult> Galletas()
        {
            var galletas = await _unitWork.Producto.ObtenerTodosAsync(filter: x => x.Categoria.Nombre == "Galleta");
            return View(galletas);
        }

        #region API para javascript
        /// <summary>
        /// Lista todos los libros registrados
        /// </summary>
        /// <returns>Json</returns>
        public async Task<IActionResult> ListarTodos()
        {
            var productos = await _unitWork.Producto.ObtenerTodosAsync(
                includeProperties: "Categoria,Receta",
                orderBy: b => b.OrderByDescending(b => b.ProductoId),
                isTracking: false);

            return Json(new { data = productos });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var productoDB = await _unitWork.Producto.ObtenerPrimeroAsync(b => b.ProductoId == id);

            if (productoDB is null)
                return Json(new { success = false, message = "Error al eliminar el producto." });

            _unitWork.Producto.Eliminar(productoDB);
            await _unitWork.GuardarAsync();
            return Json(new { success = true, message = "Producto eliminado correctamente." });
        }
        #endregion
    }
}
