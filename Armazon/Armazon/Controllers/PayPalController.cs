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
            var ppal = adminFac.getMetododePagoPayPal(id);
            if (ppal == null)
                return View("NotFoundPpal");
            else
                return View(ppal);
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
            return View();
        }

        //
        // POST: /PayPal/Edit/5

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
