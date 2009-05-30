using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Armazon.Models.DataTypes;

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

        public void AddCarritoActivo(Carrito activo)
        {
            activo.CarritoType = "Activo";
            db.Carritos.InsertOnSubmit(activo);
        }
        public Carrito getCarritoActivoByUser(int userId)
        {
            var activo = from act in db.Carritos
                         where act.CarritoType == "Activo" && act.UsuarioID == userId
                         select act;
            if (activo == null || activo.ToList().Count == 0)
                return null;
            else
            {
                Carrito activoAux = activo.ToList().First();
                return activoAux;
            }
        }
        
        
        public Carrito getCarritoActivoById(int idCarrito)
        {
            var activo = from act in db.Carritos
                         where act.CarritoType == "Activo" && act.CarritoID == idCarrito
                         select act;
            if (activo == null)
                return null;
            else
            {
                Carrito activoAux = activo.ToList().First();
                return activoAux;
            }
        }
        public void AgregarProductoCarrito(int productoId, int carritoId,int cant)
        {
            var yaEstaEnCarro = from producto in db.Producto_Carritos
                                where producto.ProductoID == productoId && producto.CarritoID == carritoId
                                select producto;

            int repeticiones = yaEstaEnCarro.ToList().Count;

            if (repeticiones > 0)
            {
                Producto_Carrito repetido = yaEstaEnCarro.ToList().First();
                repetido.Cantidad = repetido.Cantidad + cant;
                db.SubmitChanges();
            }
            else
            {
                Producto_Carrito prodCarrito = new Producto_Carrito();
                prodCarrito.ProductoID = productoId;
                prodCarrito.CarritoID = carritoId;
                prodCarrito.Cantidad = cant;
                prodCarrito.EstaEnCarrito = '0';
                db.Producto_Carritos.InsertOnSubmit(prodCarrito);
                db.SubmitChanges();
            }
        }
        public void cambiarCantidadProducto(int productoId, int carritoId, int cant)
        {
            var productoCarro = from producto in db.Producto_Carritos
                                where producto.ProductoID == productoId && producto.CarritoID == carritoId
                                select producto;
            Producto_Carrito pCarrito = productoCarro.ToList().First();
            pCarrito.Cantidad = cant;
            db.SubmitChanges();

        }
        public void deleteProducto_Carrito(int idProd, int idCarro)
        {
            var productoCarro = from producto in db.Producto_Carritos
                                where producto.ProductoID == idProd && producto.CarritoID == idCarro
                                select producto;
            Producto_Carrito pCarrito = productoCarro.ToList().First();
            db.Producto_Carritos.DeleteOnSubmit(pCarrito);
            db.SubmitChanges();
        }
        public void marcarProductosDelCarro(int idCarro)
        {
            var productoCarro = from producto in db.Producto_Carritos
                                where producto.CarritoID == idCarro
                                select producto;

            foreach (Producto_Carrito auxprodCarr in productoCarro.ToList())
            {
                auxprodCarr.EstaEnCarrito = '1';
            }
            db.SubmitChanges();
        }

        public List<Producto_Carrito> getProductosConfirmados(int idCarrito)
        {
            var productoCarro = from producto in db.Producto_Carritos
                                where (producto.CarritoID == idCarrito) && (producto.EstaEnCarrito == '1')
                                select producto;
            return productoCarro.ToList();
            
        }
        public List<DTPedido> getProductosDeCarrito(int carrito)
        {
            Producto_Carrito prodCarrito = new Producto_Carrito();
            var productosDelCarro = from prodCarr in db.Producto_Carritos
                                    where carrito == prodCarr.CarritoID
                                    select prodCarr.ProductoID;
            List<int> listaIds = productosDelCarro.ToList();
            ProductoManager prodMgr = new ProductoManager();
            List<DTPedido> listProd = new List<DTPedido>();
            foreach(int elem in listaIds)
            {
                Producto prod = prodMgr.getProducto(elem);
                DTPedido dtp = new DTPedido();
                var cant = from prodCarr in db.Producto_Carritos
                           where carrito == prodCarr.CarritoID && prod.ProductoID == prodCarr.ProductoID
                           select prodCarr.Cantidad;
                dtp.Cant = cant.ToList().First();
                dtp.Nombre = prod.Nombre;
                dtp.Id = prod.ProductoID;
                dtp.Precio = prod.Precio;
                listProd.Add(dtp);
            }
            return listProd;
        }
        public DTCarroVendido datosVenta(int carritoId)
        {

            Carrito carrito = getCarritoActivoById(carritoId);
            DTCarrito dtc = carrito.getDataType();
            List<DTPedido> listPedidos = getProductosDeCarrito(carrito.CarritoID);
            DTCarroVendido carroVendido = new DTCarroVendido(dtc, listPedidos);
            return carroVendido;
        }
        public DTCarroVendido finalizarVentaCarrito(int carritoId)
        {
            Carrito carrito = getCarritoActivoById(carritoId);
            carrito.Fecha = DateTime.Now;
            carrito.CarritoType = "Vendido";
            getCarritoActivoById(carritoId);
            ProductoManager prmgr = new ProductoManager();
            List<Producto_Carrito> listProdCarrito = getProductosConfirmados(carrito.CarritoID);

            double monto = 0;
            foreach (Producto_Carrito auxprodCarr in listProdCarrito)
            {
                monto = prmgr.getProducto(auxprodCarr.ProductoID).Precio * auxprodCarr.Cantidad + monto;

            }
            carrito.Fecha = DateTime.Now;
            carrito.Total = monto;

            DTCarroVendido dtcVendido =  datosVenta(carrito.CarritoID);   
            
            
            
            Carrito carroNuevo = new Carrito();
            carroNuevo.CarritoType = "Activo";
            carroNuevo.Total = 0;
            carroNuevo.UsuarioID = carrito.UsuarioID;

            AddCarritoActivo(carroNuevo);
            Save();
            
            return dtcVendido;
        }
        /*public void Delete(Usuario usuario)
        {
            db.Usuarios.DeleteOnSubmit(usuario);
        }
        */
        public List<DTCarrito> ventasTotalesXPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            var carritos = from c in db.Carritos
                                    select c;
            
            List<DTCarrito> lsCarrito = new List<DTCarrito>();
            foreach (Carrito carrito in carritos)
            {
                lsCarrito.Add(carrito.getDataType());
            }

            return lsCarrito;
        }

        public void Save()
        {
            db.SubmitChanges();
        }

    }
}
