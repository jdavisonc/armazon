using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;
using System.Web.Security;

namespace Armazon.Controllers
{
    public class TarjetaController : Controller
    {
        //
        // GET: /Tarjeta/

        public ActionResult Index()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var metodosDePago = adminFac.findAllMetododePago();
            
            return View(metodosDePago);
        }

        //
        // GET: /Tarjeta/Details/5

        public ActionResult Details(int id)
        {

            AdministracionFachada adminFac = new AdministracionFachada();
            var pago = adminFac.getMetododePago(id);
            if (pago == null)
                return View("NotFoundTarjeta");
            else
            {
                if (pago.GetType() == Type.GetType("Armazon.Tarjeta"))
                    return View(pago);
                else
                    if (pago.GetType() == Type.GetType("Armazon.PayPal"))
                        return View("DetailsPayPal",pago);
            }
            return null;
        }

        //
        // GET: /Tarjeta/Create

        public ActionResult Create()
        {
            List<string> list = new List<string>();
            list.Add("Visa");
            list.Add("Master Card");
            ViewData["tiposTarjeta"] = new SelectList(list);
            return View();
        } 

        //
        // POST: /Tarjeta/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            
            Tarjeta trj = new Tarjeta();
            try
            {
                // TODO: Add insert logic here
                UpdateModel(trj);
                AdministracionFachada adminFac = new AdministracionFachada();
                trj.Validada = false;
                trj.Tipo = Request.Form["tiposTarjeta"];
                Usuario usr = adminFac.getUserSession();
                Carrito carrito = adminFac.getCarritoActivoByUser(usr.UsuarioID);
                
                trj.UsuarioID = usr.UsuarioID;
                adminFac.AddTarjeta(trj);
                List<Tarjeta> ltarjetas = adminFac.getUsuarioTarjetas(usr.UsuarioID);
                carrito.MetodoDePagoID = ltarjetas.Last().MetodoDePagoID;
                adminFac.SaveCarritoActivo();
                return View("TarjetaOk");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tarjeta/Edit/5
 
        public ActionResult Edit(int id)
        {
           
            List<string> list = new List<string>();
            list.Add("Si");
            list.Add("No");
            ViewData["isValida"] = new SelectList(list);
            AdministracionFachada adminFac = new AdministracionFachada();
            var pago = adminFac.getMetododePago(id);
            if (pago == null)
                return View("NotFoundTarjeta");
            else
            {
                if (pago.GetType() == Type.GetType("Armazon.Tarjeta"))
                    return View(pago);
                else
                    if (pago.GetType() == Type.GetType("Armazon.PayPal"))
                        return View("EditPayPal",pago);
            }
            return null;
        }

        //
        // POST: /Tarjeta/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                AdministracionFachada adminFac = new AdministracionFachada();
                var pago = adminFac.getMetododePago(id);
                if (pago == null)
                    return View("NotFoundPayPal");
                else
                {
                    if (pago.GetType() == Type.GetType("Armazon.Tarjeta"))
                    {
                        Tarjeta trj = (Tarjeta)adminFac.getMetododePago(id);
                        trj.MetodoDePagoID = pago.MetodoDePagoID;
                        trj.Tipo = pago.Tipo;
                        trj.Titular = pago.Titular;
                        trj.UsuarioID = pago.UsuarioID;
                        trj.Vencimiento = pago.Vencimiento;
                        string isValida = Request.Form["isValida"];
                        if (isValida.Equals("Si"))
                            trj.Validada = true;
                        else
                            trj.Validada = false;
                        
                        trj.MetodoDePagoType = pago.MetodoDePagoType;
                        trj.Numero = pago.Numero;
                        adminFac.saveMetodoDePago();
                        return RedirectToAction("Index");

                    }
                    else
                        if (pago.GetType() == Type.GetType("Armazon.PayPal"))
                        {    
                            PayPal ppal = (PayPal)adminFac.getMetododePago(id);
                            ppal.MetodoDePagoID = pago.MetodoDePagoID;
                            ppal.MetodoDePagoType = pago.MetodoDePagoType;
                            adminFac.saveMetodoDePago();
                            return RedirectToAction("Index");           
                        }   
                           
                }
                return null;
    
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var metodo = adminFac.getMetododePago(id);
            if (metodo == null)
                return View("NotFoundTarjeta");
            else
            {
                if (metodo.GetType() == Type.GetType("Armazon.Tarjeta"))
                    return View(metodo);
                else
                    if (metodo.GetType() == Type.GetType("Armazon.PayPal"))
                        return View("DeletePayPal",metodo);
            }
            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var metodo = adminFac.getMetododePago(id);
            if (metodo == null)
                return View("NotFoundTarjeta");
            adminFac.deleteMetodoDePago(metodo);
            adminFac.saveMetodoDePago();
            return RedirectToAction("Index");
        } 
        
        public ActionResult getUsuarioTarjetas()
        {
           AdministracionFachada adminFac = new AdministracionFachada();
           MembershipUser myObject = Membership.GetUser();
           string userName = myObject.UserName.ToString();
           Usuario userSesion =  adminFac.getUsuario(userName);
           List<Tarjeta> listTarjetas = adminFac.getUsuarioTarjetas(userSesion.UsuarioID);
           return null;
        
        }
    
    
    
    
    }
}

