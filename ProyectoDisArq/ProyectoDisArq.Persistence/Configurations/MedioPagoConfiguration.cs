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
    public class MedioPagoConfiguration :IEntityTypeConfiguration<MedioPago>
    {
        public void Configure(EntityTypeBuilder<MedioPago> builder)
        {
            builder.ToTable("MedioPagos");
            builder.HasKey(c => c.MedioPagoId);

            builder.Property(ir => ir.MedioId)
                .IsRequired();
            builder.Property(ir => ir.PagoId)
                .IsRequired();

            builder.HasOne(ir => ir.Medio)
               .WithMany()
               .HasForeignKey(ir => ir.MedioId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ir => ir.Pago)
                .WithMany()
                .HasForeignKey(ir => ir.PagoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
