using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;

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
                AdministracionFachada adminSuc = new AdministracionFachada();
                adminSuc.AddTarjeta(trj);
                return RedirectToAction("Index");
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
                        trj.MetodoDePagoType = pago.MetodoDePagoType;
                        trj.Numero = Request.Form["Numero"];
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
        
    
    
    
    
    
    }
}

