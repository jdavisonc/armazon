using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Armazon;

namespace Armazon.Models.DataAccess.Administracion
{
    public class ProductoManager
    {
        private static ProductoManager instancia = null;
        private ArmazonDataContext db;

        private ProductoManager()
        {
            db = new ArmazonDataContext();
        }

        public static ProductoManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new ProductoManager();
            }
            return instancia;
        }

        public IQueryable<Producto> findAllProductos()
        {
            return db.Productos;
        }

        public IQueryable<Producto> findAllProductosXSubCategoria(int idSubCategoria)
        {
            var productos = (from Producto p in db.Productos
                             where p.SubCategoriaID == idSubCategoria
                             select p);
            return productos;
        }

        public IQueryable<Producto> findAllProductos(String fullText)
        {
            var productos = (from Producto p in db.Productos
                             where p.Nombre.StartsWith(fullText)
                             select p);
            return productos;
        }

        public Producto getProducto(int id)
        {
            return db.Productos.SingleOrDefault(c => c.ProductoID == id);
        }

        public Producto getProducto(String nombre)
        {
            return db.Productos.SingleOrDefault(c => c.Nombre == nombre);
        }

        public void Add(Producto producto)
        {
            db.Productos.InsertOnSubmit(producto);
        }

        public void Delete(Producto producto)
        {
            db.Productos.DeleteOnSubmit(producto);
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
