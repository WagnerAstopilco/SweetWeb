using Microsoft.AspNetCore.Mvc;
using ProyectoDisArq.Models;
using ProyectoDisArq.Models.ViewModels;
using ProyectoDisArq.Repositories.Interfaces;
using ProyectoDisArq.Utilities;

namespace ProyectoDisArq.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IUnitWork _unitWork;
        [BindProperty]
        public PedidoVM pedidoVM { get; set; }
        public PedidosController(IUnitWork unitWork)
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
            PedidoVM pedidoVM = new PedidoVM()
            {
                Pedido = new Pedido(),
                //ListCategorias = _unitWork.Complemento.ObtenerTodosDropdownLista("Categoria"),
                //ListRecetas = _unitWork.Complemento.ObtenerTodosDropdownLista("Receta")

            };
            return View(pedidoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoVM pedidoVM)
        {
            if (ModelState.IsValid)
            {
                await _unitWork.Pedido.AgregarAsync(pedidoVM.Pedido);
                await _unitWork.GuardarAsync();
                TempData[DS.Successful] = "Pedido creado correctamente.";
                return RedirectToAction("Index");
            }
            //pedidoVM.ListCategorias = _unitWork.Complemento.ObtenerTodosDropdownLista("Categoria");
            //pedidoVM.ListRecetas = _unitWork.Complemento.ObtenerTodosDropdownLista("Receta");
            TempData[DS.Error] = "Error al crear el producto, intente de nuevo.";
            return View(pedidoVM);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            pedidoVM = new PedidoVM();
            pedidoVM.Pedido = await _unitWork.Pedido.ObtenerPrimeroAsync(filter: c => c.PedidoId == id, includeProperties: "Categoria,Receta");
            //pedidoVM.ListCategorias = _unitWork.Complemento.ObtenerTodosDropdownLista("Categoria");
            //pedidoVM.ListRecetas = _unitWork.Complemento.ObtenerTodosDropdownLista("Receta");
            if (pedidoVM is null) return NotFound();
            return View(pedidoVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _unitWork.Pedido.Actualizar(pedido);
                await _unitWork.GuardarAsync();

                TempData[DS.Successful] = "Pedido actualizado correctamente.";
                return RedirectToAction("Index");
            }

            TempData[DS.Error] = "Error al actualizar el pedido, intente de nuevo.";
            return View(pedido);
        }
        [HttpGet]
        public async Task<ActionResult> Detail(int? id)
        {
            PedidoVM pedidoVM = new PedidoVM();
            pedidoVM.Pedido = await _unitWork.Pedido.ObtenerPrimeroAsync(filter: i => i.PedidoId == id, includeProperties: "Categoria,Receta");

            return View(pedidoVM);
        }
        [HttpPost]
        public async Task<IActionResult> Detail(int pedidoId)
        {
            pedidoVM = new PedidoVM();
            pedidoVM.Pedido = await _unitWork.Pedido.ObtenerPrimeroAsync(b => b.PedidoId == pedidoId);
            return View(pedidoVM);
        }
        #region API para javascript
        /// <summary>
        /// Lista todos los libros registrados
        /// </summary>
        /// <returns>Json</returns>
        public async Task<IActionResult> ListarTodos()
        {
            var pedidos = await _unitWork.Pedido.ObtenerTodosAsync(
                //includeProperties: "Categoria,Receta",
                orderBy: b => b.OrderByDescending(b => b.PedidoId),
                isTracking: false);

            return Json(new { data = pedidos });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var pedidoDB = await _unitWork.Pedido.ObtenerPrimeroAsync(b => b.PedidoId == id);

            if (pedidoDB is null)
                return Json(new { success = false, message = "Error al eliminar el pedido." });

            _unitWork.Pedido.Eliminar(pedidoDB);
            await _unitWork.GuardarAsync();
            return Json(new { success = true, message = "Pedido eliminado correctamente." });
        }
        #endregion
    }
}
