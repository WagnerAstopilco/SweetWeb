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
    public class ProvinciaConfiguration :IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> builder)
        {
            builder.ToTable("Provincias");

            builder.HasKey(x => x.ProvinciaId);

            builder.Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50); ;

            builder.HasOne(p=>p.Departamento)
                .WithMany()
                .HasForeignKey(p=>p.DepartamentoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
