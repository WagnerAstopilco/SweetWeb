
using Microsoft.Identity.Client;
using ProyectoDisArq.Persistence;
using ProyectoDisArq.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Repositories.Implementations
{
    public class UnitWork : IUnitWork
    {
        private readonly ProyectoDisArqContext _db;

        public ICategoriaRepository Categoria { get; private set; }
        public IAppUserRepository AppUser { get; private set; }
        public IInsumoRepository Insumo { get; private set; }
        public IInsumoRecetaRepository InsumoReceta { get; private set; }
        public IRecetaRepository Receta { get; private set; }
        public IProductoRepository Producto { get; private set; }
        public IComplementoRepository Complemento {  get; private set; }
        public IDireccionRepository Direccion { get; private set; }
        public IComplementoProductoRepository ComplementoProducto { get; private set; }

        public IPagoRepository Pago { get; private set; }
        public IMedioRepository Medio { get; private set; }
        public IMedioPagoRepository MedioPago { get; private set; }
        public IPedidoRepository Pedido { get; private set; }
        public IPedidoProductoRepository PedidoProducto { get; private set; }
        public UnitWork(ProyectoDisArqContext db)
        {
            _db = db;
            Categoria =new CategoriaRepository(_db);
            AppUser = new AppUserRepository(_db);
            Insumo=new InsumoRepository(_db);
            InsumoReceta=new InsumoRecetaRepository(_db);
            Receta=new RecetaRepository(_db);
            Producto=new ProductoRepository(_db);
            Complemento=new ComplementoRepository(_db);
            Direccion=new DireccionRepository(_db);
            ComplementoProducto=new ComplementoProductoRepository(_db);
            Pago=new PagoRepository(_db);
            Medio=new MedioRepository(_db);
            MedioPago = new MedioPagoRepository(_db);
            Pedido=new PedidoRepository(_db);
            PedidoProducto=new PedidoProductoRepository(db);
        }
        public void Dispose()
        {
            _db.Dispose();
        }
        public async Task GuardarAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
