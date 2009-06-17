using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;
using DatabaseAccess;
using Armazon.Controllers.ViewModels;
using System.Collections.Specialized;
using Armazon.Models.ServiceAccess;
using Armazon.Models.DataTypes;
using System.IO;
using System.Drawing;
using System.Web.UI;
using System.Web.Security;
using System.Data.Linq;

namespace Armazon
{
    public class MenuController : Controller
    {
        public static List<DTCategoria> getCategorias()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            IEnumerable<Categoria> categorias = administracionFachada.findAllCategorias();

            List<DTCategoria> DtCategorias = new List<DTCategoria>();
            foreach (Categoria item in categorias){
                DtCategorias.Add(item.getDataType());
            }
            return DtCategorias;
        }
        public static AddProductoCarrito getProductos()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            MembershipUser myObject = Membership.GetUser();
            if (myObject == null)
            {
                return null;
            }
            else 
            {
                string userName = myObject.UserName.ToString();
                int usuarioId = adminFac.getUsuario(userName).UsuarioID;
                Carrito carroActivo = adminFac.getCarritoActivoByUser(usuarioId);
                int carritoId = carroActivo.CarritoID;

                List<DTPedido> prods = adminFac.getProductosDeCarrito(carritoId);
                if (prods == null)
                    return null;
                else
                {
                    double montoProductos = adminFac.getMontoProductos(prods);
                    AddProductoCarrito prodsCarrito = new AddProductoCarrito();
                    prods.Reverse();
                    prodsCarrito.MontoActual = montoProductos;
                    prodsCarrito.Productos = prods;
                    return prodsCarrito;
                }
            }
        }
        public ActionResult GetTags()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            IEnumerable<Tag> tags = administracionFachada.findAllTags();
            List<DTTag> DtTags = new List<DTTag>();
            foreach (Tag item in tags)
            {
                DtTags.Add(item.getDataType());
            }
            if (DtTags.Count > 10)
            {
                DtTags.Reverse();
                DtTags = DtTags.Take(10).ToList();
                DtTags.Reverse();
                return Json(DtTags);
            }
            else
            {
                return Json(DtTags);
            }
        }

        public static List<DTTag> getTags()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            IEnumerable<Tag> tags = administracionFachada.findAllTags();
            List<DTTag> DtTags = new List<DTTag>();
            foreach (Tag item in tags)
            {
                DtTags.Add(item.getDataType());
            }
            if (DtTags.Count > 20)
            {
                return DtTags.GetRange(0, 20);
            }
            else
            {
                return DtTags;
            }
        }

        public static double getSizeTag(string TagName)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            double cantAp = administracionFachada.getSizeTag(TagName);                
            return cantAp;            
        }


        public static DTCarroVendido finalizarVentaCarrito()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            MembershipUser myObject = Membership.GetUser();
            string userName = myObject.UserName.ToString();
            int usuarioId = adminFac.getUsuario(userName).UsuarioID;
            Carrito carroActivo = adminFac.getCarritoActivoByUser(usuarioId);
            DTCarroVendido dtcv = adminFac.finalizarVentaCarrito(carroActivo.CarritoID);
            
            
            return dtcv;
                
        }
        public static DTCarroVendido datosVenta()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            return null;
        }

        public static double getMontoEnCarroActivo()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            Usuario usr = adminFac.getUserSession();
            Carrito activo = adminFac.getCarritoActivoByUser(usr.UsuarioID);
            return adminFac.getMontoCarritoActivo();
        }
        public static bool puedeComentar(int productID)
        {
            AdministracionFachada adminFach = new AdministracionFachada();
            List<Producto> listado = adminFach.getProductosComentables(adminFach.getCarritosVendidosAUsuario());
            Producto p = listado.Find(c => c.ProductoID == productID);
            if (p != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
