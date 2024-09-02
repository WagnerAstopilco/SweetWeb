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
    public class ComplementoProductoConfiguration :IEntityTypeConfiguration<ComplementoProducto>
    {
        public void Configure(EntityTypeBuilder<ComplementoProducto> builder)
        {
            builder.ToTable("ComplementoProductos");
            builder.HasKey(c => c.ComplementoProductoId);

            builder.Property(ir => ir.ComplementoId)
                .IsRequired();
            builder.Property(ir => ir.ProductoId)
                .IsRequired();

            builder.HasOne(ir => ir.Complemento)
               .WithMany()
               .HasForeignKey(ir => ir.ComplementoId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ir => ir.Producto)
                .WithMany()
                .HasForeignKey(ir => ir.ProductoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
