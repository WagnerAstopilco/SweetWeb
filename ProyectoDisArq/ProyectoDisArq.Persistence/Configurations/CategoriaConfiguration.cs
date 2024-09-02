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
    public class CategoriaConfiguration :IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");

            builder.HasKey(x => x.CategoriaId);

            builder.Property(c=>c.Nombre)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);
            builder.Property(c => c.Descripcion)
                .IsRequired(false);
        }
    }
}
