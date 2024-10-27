using ProyectoDisArq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    [TestClass]
    public class TestProductos
    {
        [TestMethod]
        public void TestCreacionProducto()
        {
            Categoria categoria = new Categoria();
            categoria.CategoriaId = 1;
            categoria.Nombre = "Tortas";
            categoria.Descripcion = "keke";
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
            producto.CategoriaId = categoria.CategoriaId;
            producto.RecetaId = receta.RecetaId;
            bool resp = false;
            if (producto.ProductoId >0 && producto.Name != "" && producto.Descripcion != "" && producto.Tipo_Masa != "" &&
                producto.Tamagno != "" && producto.Forma != "" && producto.Costo_Base > 0 && producto.Sabor != "" &&
                producto.CategoriaId >0 && producto.RecetaId > 0)
            {
                resp = true;
            }
            Assert.AreEqual(true, resp);
        }
        [TestMethod]
        public void TestCreacionProductoSinCategoria()
        {
            Categoria categoria = new Categoria();
            categoria.CategoriaId = 1;
            categoria.Nombre = "Tortas";
            categoria.Descripcion = "keke";
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
            producto.RecetaId = receta.RecetaId;
            bool resp = false;
            if (producto.ProductoId > 0 && producto.Name != "" && producto.Descripcion != "" && producto.Tipo_Masa != "" &&
                producto.Tamagno != "" && producto.Forma != "" && producto.Costo_Base > 0 && producto.Sabor != "" &&
                producto.CategoriaId > 0 && producto.RecetaId > 0)
            {
                resp = true;
            }
            Assert.AreEqual(true, resp);
        }
    }
}
