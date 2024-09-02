using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Interfaces
{
    public interface IUnitWork :IDisposable
    {
        ICategoriaRepository Categoria { get; }
        IAppUserRepository AppUser { get; }
        IInsumoRepository Insumo { get; }
        IInsumoRecetaRepository InsumoReceta { get; }
        IRecetaRepository Receta { get; }
        IProductoRepository Producto { get; }
        IComplementoRepository Complemento { get; }
        IDireccionRepository Direccion { get; }
        IComplementoProductoRepository ComplementoProducto { get; }
        IPagoRepository Pago { get; }
        IMedioRepository Medio { get; }
        IMedioPagoRepository MedioPago { get; }
        IPedidoRepository Pedido { get; }
        IPedidoProductoRepository PedidoProducto { get; }

        Task GuardarAsync();
    }
}
