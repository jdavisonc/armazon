using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Armazon;
using Armazon.Models.DataTypes;

namespace Armazon.Models.DataAccess.Administracion
{
    public class ProductoManager
    {
        private ArmazonDataContext db;

        public ProductoManager()
        {
            db = new ArmazonDataContext();
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
        public double getMontoProductos(List<DTPedido> listProd)
        {
            double MontoTotal = 0;
            foreach (DTPedido prod in listProd)
            {
                
                MontoTotal = prod.Precio * prod.Cant + MontoTotal;
            }
            return MontoTotal;
        }
        public List<string> getNombresProductos(List<Producto> listProd)
        {
            List<string> nombres = new List<string>();
            foreach (Producto prod in listProd)
            {
                string nombreAux = prod.Nombre;
                nombres.Add(nombreAux);
            }
            return nombres;
        }
        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
