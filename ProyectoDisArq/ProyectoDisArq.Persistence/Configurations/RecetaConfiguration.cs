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
    public class RecetaConfiguration : IEntityTypeConfiguration<Receta>
    {
        public void Configure(EntityTypeBuilder<Receta> builder)
        {
            builder.ToTable("Recetas");

            builder.HasKey(r => r.RecetaId);

            builder.Property(r => r.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(200);
            builder.Property(r => r.Preparacion)
                .IsRequired(false)
                .IsUnicode()
                .HasColumnType("text");
            builder.Property(r => r.Descripcion)
                .IsRequired(false)
                .IsUnicode()
                .HasColumnType("text");
        }
    }
}
