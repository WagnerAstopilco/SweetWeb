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
    public class ProductoConfiguration :IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            
            builder.HasKey(p=>p.ProductoId);

            builder.Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);
            builder.Property(p => p.Descripcion)
                .IsRequired(false)
                .IsUnicode()
                .HasColumnType("text");
            builder.Property(p=>p.Tipo_Masa)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            builder.Property(p => p.Tamagno)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(p => p.Forma)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(p => p.Costo_Base)
                .IsRequired();
            builder.Property(p => p.Sabor)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(p=>p.Pisos)
                .IsRequired();
            builder.Property(p => p.Cantidad)
                .IsRequired()
                .HasDefaultValue(true);

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
