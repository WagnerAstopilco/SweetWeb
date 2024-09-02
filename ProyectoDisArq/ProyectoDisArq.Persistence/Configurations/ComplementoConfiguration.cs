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
    public class ComplementoConfiguration :IEntityTypeConfiguration<Complemento>
    {
        public void Configure(EntityTypeBuilder<Complemento> builder)
        {
            builder.ToTable("Complementos");
            builder.HasKey(c=>c.ComplementoId);

            builder.Property(c => c.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            builder.Property(c => c.Descripcion)
                .IsRequired(false)
                .IsUnicode()
                .HasColumnType("text");
            builder.Property(c => c.Costo_gramo)
                .IsRequired();

            builder.HasOne(x => x.Categoria)
                .WithMany()
                .HasForeignKey(x => x.CategoriaId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Receta)
                .WithMany()
                .HasForeignKey(x => x.RecetaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
