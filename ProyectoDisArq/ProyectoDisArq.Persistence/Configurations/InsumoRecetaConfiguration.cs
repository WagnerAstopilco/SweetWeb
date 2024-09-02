using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDisArq.Models;

namespace ProyectoDisArq.Persistence.Configurations
{
    public class InsumoRecetaConfiguration :IEntityTypeConfiguration<InsumoReceta>
    {
        public void Configure(EntityTypeBuilder<InsumoReceta> builder)
        {
            builder.ToTable("InsumoRecetas");

            builder.HasKey(ir => ir.InsumoRecetaId);

            builder.Property(ir=>ir.InsumoId)
                .IsRequired();
            builder.Property(ir => ir.RecetaId)
                .IsRequired();
            builder.Property(ir => ir.Cantidad_uso)
                .IsRequired();
            builder.Property(ir => ir.Medida_uso)
                .IsRequired();

            builder.HasOne(ir => ir.Insumo)
               .WithMany()
               .HasForeignKey(ir => ir.InsumoId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ir => ir.Receta)
                .WithMany()
                .HasForeignKey(ir => ir.RecetaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
