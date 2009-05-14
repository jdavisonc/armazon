using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;
namespace Armazon.Controllers
{
    public class PayPalController : Controller
    {
        //
        // GET: /PayPal/

        public ActionResult Index()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var metodosDePago = adminFac.findAllMetododePago();
            return View(metodosDePago);

        }

        //
        // GET: /PayPal/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var pago = adminFac.getMetododePago(id);
            if (pago == null)
                return View("NotFoundTarjeta");
            else
            {
                if (pago.GetType() == Type.GetType("Armazon.Tarjeta"))
                    return View("DetailsTarjeta", pago);
                else
                    if (pago.GetType() == Type.GetType("Armazon.PayPal"))
                        return View(pago);
            }
            return null;
        }

        //
        // GET: /PayPal/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PayPal/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            PayPal ppal = new PayPal();
            try
            {
                // TODO: Add insert logic here
                UpdateModel(ppal);
                AdministracionFachada adminSuc = new AdministracionFachada();
                adminSuc.AddPayPal(ppal);              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
    
        }

        //
        // GET: /PayPal/Edit/5
 
        public ActionResult Edit(int id)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var pago = adminFac.getMetododePago(id);
            if (pago == null)
                return View("NotFoundTarjeta");
            else
            {
                if (pago.GetType() == Type.GetType("Armazon.Tarjeta"))
                    return View("EditTarjeta",pago);
                else
                    if (pago.GetType() == Type.GetType("Armazon.PayPal"))
                        return View(pago);
            }
            return null;
        }

        //
        // POST: /PayPal/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                AdministracionFachada adminFac = new AdministracionFachada();
                var pago = adminFac.getMetododePago(id);
                if (pago == null)
                    return View("NotFoundTarjeta");
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
                            ppal.Usuario = Request.Form["Usuario"];
                            ppal.Password = Request.Form["Password"];
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
                return View("NotFoundPayPal");
            else
            {
                if (metodo.GetType() == Type.GetType("Armazon.Tarjeta"))
                    return View("DeleteTarjeta", metodo);
                else
                    if (metodo.GetType() == Type.GetType("Armazon.PayPal"))
                        return View(metodo);
            }
            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var metodo = adminFac.getMetododePago(id);
            if (metodo == null)
                return View("NotFoundPayPal");
            adminFac.deleteMetodoDePago(metodo);
            adminFac.saveMetodoDePago();
            return RedirectToAction("Index");
        }    

    
    
    
    
    
    }
}
