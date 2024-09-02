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
    public class DistritoConfiguration :IEntityTypeConfiguration<Distrito>
    {
        public void Configure(EntityTypeBuilder<Distrito> builder)
        {
            builder.ToTable("Distritos");

            builder.HasKey(x => x.DistritoId);

            builder.Property(d => d.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50); ;

            builder.HasOne(d => d.Provincia)
                .WithMany()
                .HasForeignKey(d => d.ProvinciaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
