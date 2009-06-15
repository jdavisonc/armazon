using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Armazon;
using Armazon.Models.DataTypes;
using Armazon.ArmazonWS;

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

        public IQueryable<Producto> ProductosMasVendidos(int idSubCategoria)
        {
            var prod_carrito = (from Producto_Carrito p in db.Producto_Carritos
                             group p by p.ProductoID into g
                             select  new {prod = g.Key, cant = g.Sum(it => it.Cantidad)});

            var productos = (from Producto prod in db.Productos
                             where prod.SubCategoriaID == idSubCategoria
                             join p in prod_carrito on prod.ProductoID equals p.prod
                             orderby p.cant
                             select prod);



            return productos;
        }

        public IQueryable<Producto> ProductosMejorCalificados(int idSubCategoria)
        {
            var prod_usuario = (from Producto_Usuario p in db.Producto_Usuarios
                                group p by p.ProductoID into g
                                select new { prod = g.Key, puntaje = g.Sum(it => it.Puntaje) });

            var productos = (from Producto prod in db.Productos
                             where prod.SubCategoriaID == idSubCategoria
                             join p in prod_usuario on prod.ProductoID equals p.prod
                             orderby p.puntaje
                             select prod);



            return productos;
        }

        public IQueryable<Producto> findAllProductos(String fullText)
        {
            var productos = (from Producto p in db.Productos
                             where p.Nombre.StartsWith(fullText) && p.Tienda == null
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
        
        
        
        public double getMontoProductos(ICollection<DCCartItem> listProd)
        {
            double MontoTotal = 0;
            foreach (DCCartItem prod in listProd)
            {

                MontoTotal = getProducto(prod.ProductId).Precio * prod.Quantity + MontoTotal;
            }
            return MontoTotal;
        }

        public bool estaComentado(int productoId, int usuarioId)
        {
            var comentario = from comment in db.Producto_Usuarios
                             where comment.ProductoID == productoId && comment.UsuarioID == usuarioId
                             select comment;
            if (comentario != null)
                if (comentario.ToList().Count == 0)
                    return false;
                else 
                    return true;
            return false;
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

        public IQueryable<Producto> productosRecomendados(Producto producto)
        {
            var carritos = (from Producto_Carrito pc in db.Producto_Carritos
                            join c in db.Carritos on pc.CarritoID equals c.CarritoID
                            where pc.ProductoID == producto.ProductoID && c.CarritoType.Equals("Vendido")
                            select new { idCarrito = pc.CarritoID });

            var productos = (from Producto p in db.Productos
                             join pc in db.Producto_Carritos on p.ProductoID equals pc.ProductoID
                             join c in carritos on pc.CarritoID equals c.idCarrito
                             where p.ProductoID != producto.ProductoID && p.Tienda == null
                             select p).Distinct();
            
            return productos;
                               
        }

        public IQueryable<Producto> productosRecomendados(Usuario usuario)
        {
            var productos_usuario = (from Producto p in db.Productos
                                     join pc in db.Producto_Carritos on p.ProductoID equals pc.ProductoID
                                     join c in db.Carritos on pc.CarritoID equals c.CarritoID
                                     where c.UsuarioID == usuario.UsuarioID && p.Tienda == null && c.CarritoType.Equals("Vendido")
                                     select p).Distinct();

            

            var productos = (from Producto p in db.Productos
                             join pc in db.Producto_Carritos on p.ProductoID equals pc.ProductoID
                             join c in db.Carritos on pc.CarritoID equals c.CarritoID
                             where p.Tienda == null && c.CarritoType.Equals("Vendido") 
                             select p).Except(productos_usuario.AsEnumerable<Producto>());

            return productos;

        }

        public IQueryable<Producto> productosRecomendados()
        {
            var prodMasVendidos = (from Producto_Carrito pc in db.Producto_Carritos
                                   join c in db.Carritos on pc.CarritoID equals c.CarritoID
                                   where c.CarritoType.Equals("Vendido")
                                   group pc by pc.ProductoID into g
                                   select new { idProducto = g.Key, cant = g.Count() });

            var productos = (from Producto p in db.Productos
                             join pv in prodMasVendidos on p.ProductoID equals pv.idProducto
                             where p.Tienda == null
                             orderby pv.cant
                             select p).Distinct();

            return productos;

        }

        public IQueryable<Producto> productosAleatorios()
        {
            var productos = (from Producto p in db.Productos
                             where p.Tienda == null
                             select p).Distinct();

            return productos;

        }

        internal Producto getProducto(int tiendaID, string externalID)
        {
            return db.Productos.SingleOrDefault(c => (c.TiendaID == tiendaID && c.ExternalID == externalID ));
        }
    }
}
