using ProyectoDisArq.Models;
using System.ComponentModel.DataAnnotations;

namespace ModelTest
{
    [TestClass]
    public class TestCategoria
    {
        [TestMethod]
        public void CrearCategoria()
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = "galleta";
            categoria.Descripcion = "masa de galletas";
            categoria.CategoriaId = 10;
            bool resp = false;
            if (categoria.Nombre != "" && categoria.Descripcion != ""&& categoria.CategoriaId>0)
            {
                resp = true;
            }
            Assert.AreEqual(true, resp);
        }
        [TestMethod]
        public void CrearCategoriaIncompleta()
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = "gallet#a";
            categoria.Descripcion = "masa de galletas";
            categoria.CategoriaId = 2;
            bool resp = false;
            if (!categoria.Nombre.Contains("#") && categoria.Descripcion != "" && categoria.CategoriaId>0)
            {
                resp = true;
            }
            Assert.AreEqual(true, resp);
        }
    }
}
