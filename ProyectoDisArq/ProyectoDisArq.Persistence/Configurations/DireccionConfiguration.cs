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
    public class DireccionConfiguration :IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.ToTable("Direcciones");

            builder.HasKey(x => x.DireccionID);

            builder.Property(d => d.Tipo_via)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);
            builder.Property(d => d.Calle)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);
            builder.Property(d => d.Numero)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(10);
            builder.Property(d => d.Referencia)
                .IsRequired(false)
                .HasColumnType("text");

            builder.HasOne(d => d.Distrito)
                .WithMany()
                .HasForeignKey(d => d.DistritoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
