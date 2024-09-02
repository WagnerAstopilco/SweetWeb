using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProyectoDisArq.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDisArq.Models;

namespace WebLibreria.Persistence.InitialData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProyectoDisArqContext(serviceProvider.GetRequiredService<DbContextOptions<ProyectoDisArqContext>>()))
            {
                //datos iniciales para los departamentos
                if (context.Departamento.Any()) return;
                context.Departamento.AddRange(
                    new Departamento { Name = "Amazonas" },
                    new Departamento { Name = "Ancash" },
                    new Departamento { Name = "Apurimac" },
                    new Departamento { Name = "Arequipa" },
                    new Departamento { Name = "Ayacucho" },
                    new Departamento { Name = "Cajamarca" },
                    new Departamento { Name = "Callao" },
                    new Departamento { Name = "Cusco" },
                    new Departamento { Name = "Huancavelica" },
                    new Departamento { Name = "Huanuco" },
                    new Departamento { Name = "Ica" },
                    new Departamento { Name = "Junín" },
                    new Departamento { Name = "La Libertad" },
                    new Departamento { Name = "Lambayeque" },
                    new Departamento { Name = "Lima" },
                    new Departamento { Name = "Loreto" },
                    new Departamento { Name = "Madre de Dios" },
                    new Departamento { Name = "Moquegua" },
                    new Departamento { Name = "Pasco" },
                    new Departamento { Name = "Piura" },
                    new Departamento { Name = "Puno" },
                    new Departamento { Name = "San Martín" },
                    new Departamento { Name = "Tacna" },
                    new Departamento { Name = "Tumbes" },
                    new Departamento { Name="Ucayali"}
                    );
                context.SaveChanges();

                if (context.Provincia.Any()) return;
                context.Provincia.AddRange(
                    new Provincia { Name= "Condorcanqui", DepartamentoId=1},
                    new Provincia { Name = "Bagua", DepartamentoId = 1 },
                    new Provincia { Name = "Bongará", DepartamentoId = 1 },
                    new Provincia { Name = "Utcubamba", DepartamentoId = 1 },
                    new Provincia { Name = "Luya", DepartamentoId = 1 },
                    new Provincia { Name = "Rodríguez de Mendoza", DepartamentoId = 1 },
                    new Provincia { Name = "Chachapoyas", DepartamentoId = 1 },

                    new Provincia { Name = "Huaraz", DepartamentoId = 2 },
                    new Provincia { Name = "Aija", DepartamentoId = 2 },
                    new Provincia { Name = "Antonio Raymondi", DepartamentoId = 2 },
                    new Provincia { Name = "Asunción", DepartamentoId = 2 },
                    new Provincia { Name = "Bolognesi", DepartamentoId = 2 },
                    new Provincia { Name = "Carhuaz", DepartamentoId = 2 },
                    new Provincia { Name = "Carlos Fermín Fitzcarrald", DepartamentoId = 2 },
                    new Provincia { Name = "Casma", DepartamentoId = 2 },
                    new Provincia { Name = "Corongo", DepartamentoId = 2 },
                    new Provincia { Name = "Huari", DepartamentoId = 2 },
                    new Provincia { Name = "Huarmey", DepartamentoId = 2 },
                    new Provincia { Name = "Huaylas", DepartamentoId = 2 },
                    new Provincia { Name = "Mariscal Luzuriaga", DepartamentoId = 2 },
                    new Provincia { Name = "Ocros", DepartamentoId = 2 },
                    new Provincia { Name = "Pallasca", DepartamentoId = 2 },
                    new Provincia { Name = "Pomabamba", DepartamentoId = 2 },
                    new Provincia { Name = "Recuay", DepartamentoId = 2 },
                    new Provincia { Name = "Santa", DepartamentoId = 2 },
                    new Provincia { Name = "Sihuas", DepartamentoId = 2 },
                    new Provincia { Name = "Yungay", DepartamentoId = 2 },

                    new Provincia { Name = "Cajamarca", DepartamentoId = 5 },
                    new Provincia { Name = "Cajabamba", DepartamentoId = 5 },
                    new Provincia { Name = "Celendín", DepartamentoId = 5 },
                    new Provincia { Name = "Chota", DepartamentoId = 5 },
                    new Provincia { Name = "Contumazá", DepartamentoId = 5 },
                    new Provincia { Name = "Cutervo", DepartamentoId = 5 },
                    new Provincia { Name = "Hualgayoc", DepartamentoId = 5 },
                    new Provincia { Name = "Jaén", DepartamentoId = 5 },
                    new Provincia { Name = "San Ignacio", DepartamentoId = 5 },
                    new Provincia { Name = "San Marcos", DepartamentoId = 5 },
                    new Provincia { Name = "San Miguel", DepartamentoId = 5 },
                    new Provincia { Name = "San Pablo", DepartamentoId = 5 },
                    new Provincia { Name = "Santa Cruz", DepartamentoId = 5 }
                    );
                context.SaveChanges();

                if (context.Distrito.Any()) return;
                context.Distrito.AddRange(
                    new Distrito { Name="Asunción",ProvinciaId=28},
                    new Distrito { Name = "Cospán", ProvinciaId = 28 },
                    new Distrito { Name = "Chetilla", ProvinciaId = 28 },
                    new Distrito { Name = "Magdalena", ProvinciaId = 28 },
                    new Distrito { Name = "San Juan", ProvinciaId = 28 },
                    new Distrito { Name = "Jesús", ProvinciaId = 28 },
                    new Distrito { Name = "Cajamarca", ProvinciaId = 28 },
                    new Distrito { Name = "Llacanora", ProvinciaId = 28 },
                    new Distrito { Name = "Matara", ProvinciaId = 28 },
                    new Distrito { Name = "Namora", ProvinciaId = 28 },
                    new Distrito { Name = "Los Baños del Inca", ProvinciaId = 28 },
                    new Distrito { Name = "La Encañada", ProvinciaId = 28 }
                    );
                context.SaveChanges();

                if (context.Direccion.Any()) return;
                context.Direccion.AddRange(
                    new Direccion { Tipo_via = "Psj", Calle ="Santa Teresa" , Numero="A-9",DistritoId=7}
                    );
                context.SaveChanges();

                
            }
        }
    }
}
