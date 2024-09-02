using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDisArq.Utilities;
using ProyectoDisArq.Persistence;
using ProyectoDisArq.Models;

namespace WebLibreria.Persistence.InitialData
{
    public class DbInitialize :IDbInitialize
    {
        private readonly ProyectoDisArqContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitialize(
            ProyectoDisArqContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;

        }
        public void Initialize()
        {
            // Ejecutar migraciones pendientes
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                    _context.Database.Migrate(); // Ejcuta las migraciones pendientes
            }
            catch (Exception)
            {
                throw;
            }

            // Datos iniciales
            if (_context.Roles.Any()) return; // Si ya hay roles registrados retornar

            // Crear los roles
            _roleManager.CreateAsync(new IdentityRole(DS.Admin_Role)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(DS.Pastelero_Role)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(DS.Vendedor_Role)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(DS.Cliente_Role)).GetAwaiter().GetResult();

            //Crear un usuario administrador
            _userManager.CreateAsync(new AppUser
            {
                UserName = "admin@correo.com",
                NormalizedUserName = "ADMIN@CORREO.COM",
                NormalizedEmail = "ADMIN@CORREO.COM",
                Email = "admin@correo.com",
                EmailConfirmed = true,
                FirstName = "Usuario",
                LastName = "Administrador"
            }, "Admin123*").GetAwaiter().GetResult();

            //Asignar un role al usuario creado
            AppUser user = _context.AppUser.Where(u => u.UserName == "admin@correo.com").FirstOrDefault();
            _userManager.AddToRoleAsync(user, DS.Admin_Role).GetAwaiter().GetResult();
        }
    }
}
