using ProyectoDisArq.Models;
using System.ComponentModel.DataAnnotations;

namespace ModelTest
{
    [TestClass]
    public class TestCliente
    {
        [TestMethod]
        public void ComprobarFiltro()
        {
            Categoria categoria = new Categoria();
            categoria.CategoriaId = 1;
            categoria.Nombre = "Tortas";
            categoria.Descripcion = "keke";
            Receta receta= new Receta();
            receta.RecetaId = 1;
            receta.Name = "selva negra";
            receta.Descripcion = "test";
            receta.Preparacion = "test";
            Producto producto= new Producto();
            producto.ProductoId = 1;
            producto.Name = "selva negra";
            producto.Descripcion= "test";
            producto.Tipo_Masa = "test";
            producto.Tamagno = "1 kg";
            producto.Forma = "redonda";
            producto.Costo_Base = 60;
            producto.Sabor = "chocolate";
            producto.CategoriaId=categoria.CategoriaId;
            producto.RecetaId=receta.RecetaId;

            bool resp = false;
            if (producto.CategoriaId == categoria.CategoriaId)
            {
                resp = true;
            }
            Assert.AreEqual(true, resp);
        }
        [TestMethod]
        public void Test2()
        {
            Categoria categoria = new Categoria();
            categoria.CategoriaId = 2;
            categoria.Nombre = "Galletas";
            categoria.Descripcion = "galleta";
            Receta receta = new Receta();
            receta.RecetaId = 1;
            receta.Name = "selva negra";
            receta.Descripcion = "test";
            receta.Preparacion = "test";
            Producto producto = new Producto();
            producto.ProductoId = 1;
            producto.Name = "selva negra";
            producto.Descripcion = "test";
            producto.Tipo_Masa = "test";
            producto.Tamagno = "1 kg";
            producto.Forma = "redonda";
            producto.Costo_Base = 60;
            producto.Sabor = "chocolate";
            producto.CategoriaId = 1;
            producto.RecetaId = 1;

            bool resp = false;
            if (producto.CategoriaId == categoria.CategoriaId)
            {
                resp = true;
            }
            Assert.AreEqual(true, resp);
        }
    }
}
