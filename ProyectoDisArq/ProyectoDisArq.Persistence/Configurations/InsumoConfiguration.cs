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
    public class InsumoConfiguration :IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {
            builder.ToTable("Insumos");

            builder.HasKey(x => x.InsumoId);

            builder.Property(i => i.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(40);
            builder.Property(i => i.Stock)
                .IsRequired();
            builder.Property(i => i.Unidad_Medida)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(10);
            builder.Property(i => i.Descripcion)
                .IsRequired()
                .IsUnicode()
                .HasColumnType("text");

            builder.Property(i=>i.UpdatedAt)
                .IsRequired();

            builder.HasOne(x => x.Categoria)
                .WithMany()
                .HasForeignKey(x => x.CategoriaId)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
