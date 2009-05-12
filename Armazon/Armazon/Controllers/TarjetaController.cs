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
            var tarjeta = adminFac.getMetododePagoTarjeta(id); 
            if (tarjeta == null)
                return View("NotFoundTarjeta");
            else
                return View(tarjeta);
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
            return View();
        }

        //
        // POST: /Tarjeta/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
