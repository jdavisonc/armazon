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

        public ActionResult Index()
        {
            List<string> list = new List<string>();
            list.Add("PayPal");
            list.Add("Tarjeta");
            ViewData["pagos"] = new SelectList(list);            
            AdministracionFachada adminFac = new AdministracionFachada();
            MembershipUser myObject = Membership.GetUser();
            string userName = myObject.UserName.ToString();
            Carrito carrito = adminFac.getCarritoOfUser(userName);
            List<DTPedido> listPedido = adminFac.getProductosDeCarrito(carrito.CarritoID);
            return View(listPedido);
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
                   return RedirectToAction("Index","Tarjeta");
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
