using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Armazon.Models.DataAccess.Administracion
{
    public class CarritoManager
    {
        private ArmazonDataContext db;

        public CarritoManager()
        {
            db = new ArmazonDataContext();
        }

        /*public IQueryable<Carrito> findAllCarritoVendido()
        {
            return db.Usuarios;
        }

        public IQueryable<Carrito> findAllCarritoVendido()
        {
            return db.Usuarios;
        }
        public Carrito getUsuario(int id)
        {
            return db.Usuarios.SingleOrDefault(c => c.UsuarioID == id);
        }
        
        public Usuario getUsuario(string userName)
        {
            return db.Usuarios.SingleOrDefault(c => c.Nombre == userName);
        }*/

        public void AddCarritoActivo(Activo activo)
        {
            db.Carritos.InsertOnSubmit(activo);
        }
        public Activo getCarritoActivoByUser(int userId)
        {
            var activo = from act in db.Carritos
                         where act is Activo && act.UsuarioID == userId
                         select act;
            if (activo == null)
                return null;
            else
            {
                Activo activoAux = (Activo)activo.ToList().First();
                return activoAux;
            }
        }
        
        
        public Activo getCarritoActivoById(int idCarrito)
        {
            var activo = from act in db.Carritos
                         where act is Activo && act.CarritoID == idCarrito
                         select act;
            if (activo == null)
                return null;
            else
            {
                Activo activoAux = (Activo)activo.ToList().First();
                return activoAux;
            }
        }
        public void AgregarProductoCarrito(int productoId, int carritoId)
        {
            Producto_Carrito prodCarrito = new Producto_Carrito();
            prodCarrito.ProductoID = productoId;
            prodCarrito.CarritoID = carritoId;
            prodCarrito.EstaEnCarrito = '0';
            db.Producto_Carritos.InsertOnSubmit(prodCarrito);
            db.SubmitChanges();
        }
        public List<Producto> getProductosDeCarrito(int carrito)
        {
            Producto_Carrito prodCarrito = new Producto_Carrito();
            var productosDelCarro = from prodCarr in db.Producto_Carritos
                                    where carrito == prodCarr.CarritoID
                                    select prodCarr.ProductoID;
            List<int> listaIds = productosDelCarro.ToList();
            ProductoManager prodMgr = new ProductoManager();
            List<Producto> listProd = new List<Producto>();
            foreach(int elem in listaIds)
            {
                Producto prod = prodMgr.getProducto(elem);
                listProd.Add(prod);
            }
            return listProd;
        }
        /*public void Delete(Usuario usuario)
        {
            db.Usuarios.DeleteOnSubmit(usuario);
        }
        */
        public void Save()
        {
            db.SubmitChanges();
        }

    }
}
