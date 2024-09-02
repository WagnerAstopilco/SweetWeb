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
    internal class PagoConfiguration : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("Pagos");
            builder.HasKey(p => p.PagoId);

            builder.Property(p => p.Monto_Pendiente)
                .IsRequired();
            builder.Property(p => p.Estado)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
