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
    public class MedioConfiguration :IEntityTypeConfiguration<Medio>
    {
        public void Configure(EntityTypeBuilder<Medio> builder)
        {
            builder.ToTable("Medios");

            builder.HasKey(m=>m.MedioId);

            builder.Property(m => m.Tipo)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(30);
            builder.Property(m => m.Num_tarjeta)
                .IsRequired(false);
            builder.Property(m => m.Moneda)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(m =>m.Monto)
                .IsRequired();
            builder.Property(p => p.Estado)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
