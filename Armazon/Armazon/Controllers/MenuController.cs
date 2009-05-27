using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.UI;
using Armazon.Models.DataTypes;
using Armazon.Models;
using System.Web.Security;

namespace Armazon
{
    public class MenuController : TemplateControl
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
        public static List<DTTag> getTags()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            IEnumerable<Tag> tags = administracionFachada.findAllTags();
            List<DTTag> DtTags = new List<DTTag>();
            foreach (Tag item in tags)
            {
                DtTags.Add(item.getDataType());
            }
            return DtTags;
        }
        public static double getSizeTag(string TagName)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            double cantAp = administracionFachada.getSizeTag(TagName);                
            return cantAp;            
        }
    }
}
