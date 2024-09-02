using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoDisArq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDisArq.Persistence.Configurations
{
    public class PedidoProductoConfiguration :IEntityTypeConfiguration<PedidoProducto>
    {
        public void Configure(EntityTypeBuilder<PedidoProducto> builder)
        {
            builder.ToTable("PedidoProductos");
            builder.HasKey(c => c.PedidoProductoId);

            builder.Property(ir => ir.PedidoId)
                .IsRequired();
            builder.Property(ir => ir.ProductoId)
                .IsRequired();

            builder.HasOne(ir => ir.Pedido)
               .WithMany()
               .HasForeignKey(ir => ir.PedidoId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ir => ir.Producto)
                .WithMany()
                .HasForeignKey(ir => ir.ProductoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
