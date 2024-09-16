using ProyectoDisArq.Models;
using ProyectoDisArq.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    [TestClass]
    public class TestAdministrador
    {
        [TestMethod]
        public void CrearAdministrador()
        {
            AppUser usuario = new AppUser();
            usuario.FirstName = "admin";
            usuario.LastName = "admin";
            usuario.PhoneNumber = "948571138";
            usuario.Email = "Administrador@correo.com";
            usuario.PasswordHash = "password";
            usuario.Role = "Admin";
            bool resp = false;
            if (usuario.Role == DS.Admin_Role)
            {
                resp = true;
            }
            Assert.AreEqual(true, resp);
        }
        [TestMethod]
        public void CrearUsuario()
        {
            AppUser usuario = new AppUser();
            usuario.FirstName = "client";
            usuario.LastName = "client";
            usuario.PhoneNumber = "948571138";
            usuario.Email = "Cliente@correo.com";
            usuario.PasswordHash = "password";
            bool resp = false;
            if (usuario.Role == DS.Admin_Role)
            {
                resp = true;
            }
            Assert.AreEqual(true, resp);
        }
    }
}
