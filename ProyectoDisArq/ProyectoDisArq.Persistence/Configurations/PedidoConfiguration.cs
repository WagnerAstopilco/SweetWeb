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
    public class PedidoConfiguration :IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => p.PedidoId);

            builder.Property(p => p.Tipo_Venta)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            builder.Property(p => p.Autorizado_Nombres)
                .IsRequired(false)
                .IsUnicode()
                .HasMaxLength(100);
            builder.Property(p => p.Autorizado_Apellidos)
                .IsRequired(false)
                .IsUnicode()
                .HasMaxLength(100);
            builder.Property(p => p.Authorizado_Dni)
                .IsRequired(false)
                .IsUnicode()
                .HasMaxLength(8);
            builder.Property(p => p.Creado)
                .IsRequired();
            builder.Property(p => p.Fecha_entrega)
                .IsRequired();
            builder.Property(p => p.Estado)
                .IsRequired();
            builder.Property(p => p.Dni_titular)
                .IsRequired()
                .HasMaxLength(8);

            builder.HasOne(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Pago)
                .WithMany()
                .HasForeignKey(x => x.PagoId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.DireccionEntrega)
                .WithMany()
                .HasForeignKey(x => x.DireccionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
