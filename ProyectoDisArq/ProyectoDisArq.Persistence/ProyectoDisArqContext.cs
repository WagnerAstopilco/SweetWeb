using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoDisArq.Models;

namespace ProyectoDisArq.Persistence
{
    public class ProyectoDisArqContext : IdentityDbContext
    {
        public ProyectoDisArqContext(DbContextOptions<ProyectoDisArqContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Insumo> Insumo { get; set; }
        public DbSet<InsumoReceta> InsumoReceta { get; set; }
        public DbSet<Receta> Receta { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Complemento> Complemento { get; set; }
        public DbSet<ComplementoProducto> ComplementoProducto { get; set; }
        public DbSet<Medio> Medio { get; set; } 
        public DbSet<Pago> Pago { get; set; }
        public DbSet<MedioPago> MedioPago { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoProducto> PedidoProducto { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Indica que la configuracion de los modelos está en un archivo externo: Configuration/ Configurations
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
