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
    public class DepartamentoConfiguration :IEntityTypeConfiguration<Departamento>
    {
       public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamentos");

            builder.HasKey(x => x.DepartamentoId);

            builder.Property(d => d.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(25);
        }
    }
}
