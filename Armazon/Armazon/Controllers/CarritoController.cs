using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;
using MvcApplication1.Controllers;
using System.Web.Security;
using Armazon.Models.DataTypes;

namespace Armazon.Controllers
{
    public class CarritoController : Controller
    {
        //
        // GET: /Carrito/

        public ActionResult Index(string error)
        {

            if (error != null)
            {
                ViewData["errorTarjeta"] = error;
            }
                
                List<string> list = new List<string>();
                list.Add("PayPal");
                list.Add("Tarjeta");
                ViewData["pagos"] = new SelectList(list);
                AdministracionFachada adminFac = new AdministracionFachada();
                Usuario usr =  adminFac.getUserSession();
                if (usr != null)
                {
                    Carrito carrito = adminFac.getCarritoActivoByUser(usr.UsuarioID);
                    List<DTPedido> listPedido = adminFac.getProductosDeCarrito(carrito.CarritoID);
                    return View(listPedido);
                }
                else
                    return RedirectToAction("logOn","Account");
            
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(FormCollection collection)
        {
           AdministracionFachada adminFac = new AdministracionFachada();
           MembershipUser myObject = Membership.GetUser();
           string userName = myObject.UserName.ToString();
           Carrito carrito = adminFac.getCarritoOfUser(userName);
           adminFac.marcarProductosDelCarro(carrito.CarritoID);
           string selecItem =  Request.Form["pagos"];
           if (selecItem.Equals("PayPal"))
               return RedirectToAction("Create", "PayPal");
           else
               if (selecItem.Equals("Tarjeta"))
                   return RedirectToAction("Create", "Tarjeta");
           return null;
        }
        
        
        
        //
        // GET: /Carrito/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Carrito/Create

        public ActionResult Create()
        {
            
            return View();
        } 

        //
        // POST: /Carrito/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Carrito/Edit/5
 
        public ActionResult Edit(int id)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            MembershipUser myObject = Membership.GetUser();
            string userName = myObject.UserName.ToString();
            Carrito carrito = adminFac.getCarritoOfUser(userName);
            List<DTPedido> listPedido = adminFac.getProductosDeCarrito(carrito.CarritoID);
            List<string> list = new List<string>();
            for (int i = 1; i <= 19; i++)
                list.Add(i.ToString());
            
            ViewData["CantProd"] = new SelectList(list);
            return View(listPedido[id]);
        }

        //
        // POST: /Carrito/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                DTPedido dtp = null;
                int idProd = int.Parse(Request.Form["Id"]);
                int cantProd = int.Parse(Request.Form["Cant"]);
                AdministracionFachada adminFac = new AdministracionFachada();
                MembershipUser myObject = Membership.GetUser();
                string userName = myObject.UserName.ToString();
                Carrito carrito = adminFac.getCarritoOfUser(userName);
                adminFac.cambiarCantidadProducto(idProd, carrito.CarritoID, cantProd);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        
        public ActionResult Delete(int id)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            MembershipUser myObject = Membership.GetUser();
            string userName = myObject.UserName.ToString();
            Carrito carrito = adminFac.getCarritoOfUser(userName);
            List<DTPedido> listPedido = adminFac.getProductosDeCarrito(carrito.CarritoID);
            int idProd = listPedido[id].Id;
            adminFac.deleteProducto_Carrito(idProd, carrito.CarritoID);
            return RedirectToAction("Index");
        }



        
        public ActionResult comprarCarrito()
        {

            /*AdministracionFachada adminFac = new AdministracionFachada();
            MembershipUser myObject = Membership.GetUser();
            string userName = myObject.UserName.ToString();
            Carrito carrito = adminFac.getCarritoOfUser(userName);            
            adminFac.marcarProductosDelCarro(carrito.CarritoID);
            return RedirectToAction("Index"); */
            
            
            return null;
        }

        

    }
}
